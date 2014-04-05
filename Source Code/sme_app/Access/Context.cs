


using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace Sme.Data
{
    public partial class sm3DB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        public static IDataProvider DefaultDataProvider { get; set; }

        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public sm3DB() 
        {
            if (DefaultDataProvider == null) {
                DataProvider = ProviderFactory.GetProvider("SMEConnection");
            }
            else {
                DataProvider = DefaultDataProvider;
            }
            Init();
        }

        public sm3DB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public sm3DB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
        public Query<tblBanner> tblBanners { get; set; }
        public Query<tblalbumfoto> tblalbumfotos { get; set; }
        public Query<tbldica> tbldicas { get; set; }
        public Query<tblfoto> tblfotos { get; set; }
        public Query<tbllogin> tbllogins { get; set; }
        public Query<tblnossosservico> tblnossosservicos { get; set; }
        public Query<tblnoticia> tblnoticias { get; set; }
        public Query<tblpaginaempresa> tblpaginaempresas { get; set; }
        public Query<tblpaginaestruturaorganizacional> tblpaginaestruturaorganizacionals { get; set; }
        public Query<tblpaginamissao> tblpaginamissaos { get; set; }
        public Query<tblpaginaprofissionai> tblpaginaprofissionais { get; set; }
        public Query<tblpaginavisao> tblpaginavisaos { get; set; }
        public Query<tblparametro> tblparametros { get; set; }
        public Query<tblvalore> tblvalores { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
            tblBanners = new Query<tblBanner>(provider);
            tblalbumfotos = new Query<tblalbumfoto>(provider);
            tbldicas = new Query<tbldica>(provider);
            tblfotos = new Query<tblfoto>(provider);
            tbllogins = new Query<tbllogin>(provider);
            tblnossosservicos = new Query<tblnossosservico>(provider);
            tblnoticias = new Query<tblnoticia>(provider);
            tblpaginaempresas = new Query<tblpaginaempresa>(provider);
            tblpaginaestruturaorganizacionals = new Query<tblpaginaestruturaorganizacional>(provider);
            tblpaginamissaos = new Query<tblpaginamissao>(provider);
            tblpaginaprofissionais = new Query<tblpaginaprofissionai>(provider);
            tblpaginavisaos = new Query<tblpaginavisao>(provider);
            tblparametros = new Query<tblparametro>(provider);
            tblvalores = new Query<tblvalore>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            	DataProvider.Schema.Tables.Add(new tblBannersTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblalbumfotosTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tbldicasTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblfotosTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblloginTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblnossosservicosTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblnoticiasTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblpaginaempresaTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblpaginaestruturaorganizacionalTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblpaginamissaoTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblpaginaprofissionaisTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblpaginavisaoTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblparametrosTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new tblvaloresTable(DataProvider));
            }
            #endregion
        }
        

        #region ' Helpers '
            
        internal static DateTime DateTimeNowTruncatedDownToSecond() {
            var now = DateTime.Now;
            return now.AddTicks(-now.Ticks % TimeSpan.TicksPerSecond);
        }

        #endregion

    }
}
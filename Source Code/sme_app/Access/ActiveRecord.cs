


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace Sme.Data
{
    
    
    /// <summary>
    /// A class which represents the tblBanners table in the sm3 Database.
    /// </summary>
    public partial class tblBanner: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblBanner> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblBanner>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblBanner> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblBanner item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblBanner item=new tblBanner();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblBanner> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblBanner(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblBanner.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblBanner>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblBanner(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblBanner(Expression<Func<tblBanner, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblBanner> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblBanner> _repo;
            
            if(db.TestMode){
                tblBanner.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblBanner>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblBanner> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblBanner SingleOrDefault(Expression<Func<tblBanner, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblBanner single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblBanner SingleOrDefault(Expression<Func<tblBanner, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblBanner single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblBanner, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblBanner, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblBanner> Find(Expression<Func<tblBanner, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblBanner> Find(Expression<Func<tblBanner, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblBanner> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblBanner> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblBanner> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblBanner> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblBanner> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblBanner> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_banner";
        }

        public object KeyValue()
        {
            return this.id_banner;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.nome.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblBanner)){
                tblBanner compare=(tblBanner)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_banner;
        }
        
        public string DescriptorValue()
        {
                            return this.nome.ToString();
                    }

        public string DescriptorColumn() {
            return "nome";
        }
        public static string GetKeyColumn()
        {
            return "id_banner";
        }        
        public static string GetDescriptorColumn()
        {
            return "nome";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_banner;
        public int id_banner
        {
            get { return _id_banner; }
            set
            {
                if(_id_banner!=value){
                    _id_banner=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_banner");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nome;
        public string nome
        {
            get { return _nome; }
            set
            {
                if(_nome!=value){
                    _nome=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nome");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _path;
        public string path
        {
            get { return _path; }
            set
            {
                if(_path!=value){
                    _path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nome_arquivo;
        public string nome_arquivo
        {
            get { return _nome_arquivo; }
            set
            {
                if(_nome_arquivo!=value){
                    _nome_arquivo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nome_arquivo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _dt_cadastro;
        public DateTime dt_cadastro
        {
            get { return _dt_cadastro; }
            set
            {
                if(_dt_cadastro!=value){
                    _dt_cadastro=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="dt_cadastro");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _is_ativo;
        public bool? is_ativo
        {
            get { return _is_ativo; }
            set
            {
                if(_is_ativo!=value){
                    _is_ativo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="is_ativo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _path_thumb;
        public string path_thumb
        {
            get { return _path_thumb; }
            set
            {
                if(_path_thumb!=value){
                    _path_thumb=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="path_thumb");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nome_arquivo_thumb;
        public string nome_arquivo_thumb
        {
            get { return _nome_arquivo_thumb; }
            set
            {
                if(_nome_arquivo_thumb!=value){
                    _nome_arquivo_thumb=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nome_arquivo_thumb");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set
            {
                if(_descricao!=value){
                    _descricao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="descricao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblBanner, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblalbumfotos table in the sm3 Database.
    /// </summary>
    public partial class tblalbumfoto: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblalbumfoto> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblalbumfoto>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblalbumfoto> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblalbumfoto item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblalbumfoto item=new tblalbumfoto();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblalbumfoto> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblalbumfoto(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblalbumfoto.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblalbumfoto>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblalbumfoto(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblalbumfoto(Expression<Func<tblalbumfoto, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblalbumfoto> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblalbumfoto> _repo;
            
            if(db.TestMode){
                tblalbumfoto.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblalbumfoto>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblalbumfoto> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblalbumfoto SingleOrDefault(Expression<Func<tblalbumfoto, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblalbumfoto single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblalbumfoto SingleOrDefault(Expression<Func<tblalbumfoto, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblalbumfoto single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblalbumfoto, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblalbumfoto, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblalbumfoto> Find(Expression<Func<tblalbumfoto, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblalbumfoto> Find(Expression<Func<tblalbumfoto, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblalbumfoto> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblalbumfoto> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblalbumfoto> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblalbumfoto> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblalbumfoto> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblalbumfoto> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_album_foto";
        }

        public object KeyValue()
        {
            return this.id_album_foto;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.nome.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblalbumfoto)){
                tblalbumfoto compare=(tblalbumfoto)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_album_foto;
        }
        
        public string DescriptorValue()
        {
                            return this.nome.ToString();
                    }

        public string DescriptorColumn() {
            return "nome";
        }
        public static string GetKeyColumn()
        {
            return "id_album_foto";
        }        
        public static string GetDescriptorColumn()
        {
            return "nome";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_album_foto;
        public int id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nome;
        public string nome
        {
            get { return _nome; }
            set
            {
                if(_nome!=value){
                    _nome=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nome");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set
            {
                if(_descricao!=value){
                    _descricao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="descricao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _is_ativo;
        public bool? is_ativo
        {
            get { return _is_ativo; }
            set
            {
                if(_is_ativo!=value){
                    _is_ativo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="is_ativo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _pagina_pai;
        public string pagina_pai
        {
            get { return _pagina_pai; }
            set
            {
                if(_pagina_pai!=value){
                    _pagina_pai=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="pagina_pai");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _capa_album_path;
        public string capa_album_path
        {
            get { return _capa_album_path; }
            set
            {
                if(_capa_album_path!=value){
                    _capa_album_path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="capa_album_path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _capa_album_file;
        public string capa_album_file
        {
            get { return _capa_album_file; }
            set
            {
                if(_capa_album_file!=value){
                    _capa_album_file=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="capa_album_file");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _foto_album_path;
        public string foto_album_path
        {
            get { return _foto_album_path; }
            set
            {
                if(_foto_album_path!=value){
                    _foto_album_path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="foto_album_path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _foto_album_file;
        public string foto_album_file
        {
            get { return _foto_album_file; }
            set
            {
                if(_foto_album_file!=value){
                    _foto_album_file=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="foto_album_file");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblalbumfoto, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tbldicas table in the sm3 Database.
    /// </summary>
    public partial class tbldica: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tbldica> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tbldica>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tbldica> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tbldica item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tbldica item=new tbldica();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tbldica> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tbldica(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tbldica.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tbldica>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tbldica(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tbldica(Expression<Func<tbldica, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tbldica> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tbldica> _repo;
            
            if(db.TestMode){
                tbldica.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tbldica>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tbldica> GetRepo(){
            return GetRepo("","");
        }
        
        public static tbldica SingleOrDefault(Expression<Func<tbldica, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tbldica single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tbldica SingleOrDefault(Expression<Func<tbldica, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tbldica single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tbldica, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tbldica, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tbldica> Find(Expression<Func<tbldica, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tbldica> Find(Expression<Func<tbldica, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tbldica> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tbldica> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tbldica> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tbldica> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tbldica> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tbldica> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_dica";
        }

        public object KeyValue()
        {
            return this.id_dica;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.titulo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tbldica)){
                tbldica compare=(tbldica)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_dica;
        }
        
        public string DescriptorValue()
        {
                            return this.titulo.ToString();
                    }

        public string DescriptorColumn() {
            return "titulo";
        }
        public static string GetKeyColumn()
        {
            return "id_dica";
        }        
        public static string GetDescriptorColumn()
        {
            return "titulo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_dica;
        public int id_dica
        {
            get { return _id_dica; }
            set
            {
                if(_id_dica!=value){
                    _id_dica=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_dica");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _titulo;
        public string titulo
        {
            get { return _titulo; }
            set
            {
                if(_titulo!=value){
                    _titulo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="titulo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set
            {
                if(_descricao!=value){
                    _descricao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="descricao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _fonte;
        public string fonte
        {
            get { return _fonte; }
            set
            {
                if(_fonte!=value){
                    _fonte=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="fonte");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _dt_criacao;
        public DateTime dt_criacao
        {
            get { return _dt_criacao; }
            set
            {
                if(_dt_criacao!=value){
                    _dt_criacao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="dt_criacao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tbldica, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblfotos table in the sm3 Database.
    /// </summary>
    public partial class tblfoto: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblfoto> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblfoto>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblfoto> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblfoto item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblfoto item=new tblfoto();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblfoto> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblfoto(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblfoto.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblfoto>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblfoto(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblfoto(Expression<Func<tblfoto, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblfoto> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblfoto> _repo;
            
            if(db.TestMode){
                tblfoto.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblfoto>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblfoto> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblfoto SingleOrDefault(Expression<Func<tblfoto, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblfoto single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblfoto SingleOrDefault(Expression<Func<tblfoto, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblfoto single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblfoto, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblfoto, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblfoto> Find(Expression<Func<tblfoto, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblfoto> Find(Expression<Func<tblfoto, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblfoto> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblfoto> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblfoto> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblfoto> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblfoto> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblfoto> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_foto";
        }

        public object KeyValue()
        {
            return this.id_foto;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.nome.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblfoto)){
                tblfoto compare=(tblfoto)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_foto;
        }
        
        public string DescriptorValue()
        {
                            return this.nome.ToString();
                    }

        public string DescriptorColumn() {
            return "nome";
        }
        public static string GetKeyColumn()
        {
            return "id_foto";
        }        
        public static string GetDescriptorColumn()
        {
            return "nome";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_foto;
        public int id_foto
        {
            get { return _id_foto; }
            set
            {
                if(_id_foto!=value){
                    _id_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nome;
        public string nome
        {
            get { return _nome; }
            set
            {
                if(_nome!=value){
                    _nome=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nome");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set
            {
                if(_descricao!=value){
                    _descricao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="descricao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _path;
        public string path
        {
            get { return _path; }
            set
            {
                if(_path!=value){
                    _path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _arquivo;
        public string arquivo
        {
            get { return _arquivo; }
            set
            {
                if(_arquivo!=value){
                    _arquivo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="arquivo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _path_thumb;
        public string path_thumb
        {
            get { return _path_thumb; }
            set
            {
                if(_path_thumb!=value){
                    _path_thumb=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="path_thumb");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _arquivo_thumb;
        public string arquivo_thumb
        {
            get { return _arquivo_thumb; }
            set
            {
                if(_arquivo_thumb!=value){
                    _arquivo_thumb=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="arquivo_thumb");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblfoto, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tbllogin table in the sm3 Database.
    /// </summary>
    public partial class tbllogin: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tbllogin> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tbllogin>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tbllogin> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tbllogin item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tbllogin item=new tbllogin();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tbllogin> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tbllogin(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tbllogin.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tbllogin>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tbllogin(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tbllogin(Expression<Func<tbllogin, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tbllogin> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tbllogin> _repo;
            
            if(db.TestMode){
                tbllogin.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tbllogin>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tbllogin> GetRepo(){
            return GetRepo("","");
        }
        
        public static tbllogin SingleOrDefault(Expression<Func<tbllogin, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tbllogin single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tbllogin SingleOrDefault(Expression<Func<tbllogin, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tbllogin single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tbllogin, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tbllogin, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tbllogin> Find(Expression<Func<tbllogin, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tbllogin> Find(Expression<Func<tbllogin, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tbllogin> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tbllogin> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tbllogin> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tbllogin> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tbllogin> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tbllogin> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_login";
        }

        public object KeyValue()
        {
            return this.id_login;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.login.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tbllogin)){
                tbllogin compare=(tbllogin)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_login;
        }
        
        public string DescriptorValue()
        {
                            return this.login.ToString();
                    }

        public string DescriptorColumn() {
            return "login";
        }
        public static string GetKeyColumn()
        {
            return "id_login";
        }        
        public static string GetDescriptorColumn()
        {
            return "login";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_login;
        public int id_login
        {
            get { return _id_login; }
            set
            {
                if(_id_login!=value){
                    _id_login=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_login");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _login;
        public string login
        {
            get { return _login; }
            set
            {
                if(_login!=value){
                    _login=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="login");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _senha;
        public string senha
        {
            get { return _senha; }
            set
            {
                if(_senha!=value){
                    _senha=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="senha");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _nome;
        public string nome
        {
            get { return _nome; }
            set
            {
                if(_nome!=value){
                    _nome=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="nome");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tbllogin, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblnossosservicos table in the sm3 Database.
    /// </summary>
    public partial class tblnossosservico: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblnossosservico> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblnossosservico>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblnossosservico> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblnossosservico item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblnossosservico item=new tblnossosservico();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblnossosservico> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblnossosservico(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblnossosservico.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblnossosservico>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblnossosservico(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblnossosservico(Expression<Func<tblnossosservico, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblnossosservico> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblnossosservico> _repo;
            
            if(db.TestMode){
                tblnossosservico.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblnossosservico>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblnossosservico> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblnossosservico SingleOrDefault(Expression<Func<tblnossosservico, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblnossosservico single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblnossosservico SingleOrDefault(Expression<Func<tblnossosservico, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblnossosservico single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblnossosservico, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblnossosservico, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblnossosservico> Find(Expression<Func<tblnossosservico, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblnossosservico> Find(Expression<Func<tblnossosservico, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblnossosservico> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblnossosservico> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblnossosservico> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblnossosservico> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblnossosservico> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblnossosservico> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina_servicos";
        }

        public object KeyValue()
        {
            return this.id_pagina_servicos;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblnossosservico)){
                tblnossosservico compare=(tblnossosservico)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina_servicos;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina_servicos";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina_servicos;
        public int id_pagina_servicos
        {
            get { return _id_pagina_servicos; }
            set
            {
                if(_id_pagina_servicos!=value){
                    _id_pagina_servicos=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina_servicos");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblnossosservico, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblnoticias table in the sm3 Database.
    /// </summary>
    public partial class tblnoticia: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblnoticia> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblnoticia>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblnoticia> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblnoticia item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblnoticia item=new tblnoticia();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblnoticia> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblnoticia(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblnoticia.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblnoticia>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblnoticia(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblnoticia(Expression<Func<tblnoticia, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblnoticia> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblnoticia> _repo;
            
            if(db.TestMode){
                tblnoticia.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblnoticia>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblnoticia> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblnoticia SingleOrDefault(Expression<Func<tblnoticia, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblnoticia single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblnoticia SingleOrDefault(Expression<Func<tblnoticia, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblnoticia single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblnoticia, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblnoticia, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblnoticia> Find(Expression<Func<tblnoticia, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblnoticia> Find(Expression<Func<tblnoticia, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblnoticia> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblnoticia> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblnoticia> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblnoticia> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblnoticia> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblnoticia> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_noticia";
        }

        public object KeyValue()
        {
            return this.id_noticia;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.titulo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblnoticia)){
                tblnoticia compare=(tblnoticia)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_noticia;
        }
        
        public string DescriptorValue()
        {
                            return this.titulo.ToString();
                    }

        public string DescriptorColumn() {
            return "titulo";
        }
        public static string GetKeyColumn()
        {
            return "id_noticia";
        }        
        public static string GetDescriptorColumn()
        {
            return "titulo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_noticia;
        public int id_noticia
        {
            get { return _id_noticia; }
            set
            {
                if(_id_noticia!=value){
                    _id_noticia=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_noticia");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _titulo;
        public string titulo
        {
            get { return _titulo; }
            set
            {
                if(_titulo!=value){
                    _titulo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="titulo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _descricao;
        public string descricao
        {
            get { return _descricao; }
            set
            {
                if(_descricao!=value){
                    _descricao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="descricao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _fonte;
        public string fonte
        {
            get { return _fonte; }
            set
            {
                if(_fonte!=value){
                    _fonte=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="fonte");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _dt_criacao;
        public DateTime dt_criacao
        {
            get { return _dt_criacao; }
            set
            {
                if(_dt_criacao!=value){
                    _dt_criacao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="dt_criacao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblnoticia, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblpaginaempresa table in the sm3 Database.
    /// </summary>
    public partial class tblpaginaempresa: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblpaginaempresa> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblpaginaempresa>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblpaginaempresa> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblpaginaempresa item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblpaginaempresa item=new tblpaginaempresa();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblpaginaempresa> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblpaginaempresa(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblpaginaempresa.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginaempresa>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblpaginaempresa(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblpaginaempresa(Expression<Func<tblpaginaempresa, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblpaginaempresa> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblpaginaempresa> _repo;
            
            if(db.TestMode){
                tblpaginaempresa.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginaempresa>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblpaginaempresa> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblpaginaempresa SingleOrDefault(Expression<Func<tblpaginaempresa, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblpaginaempresa single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblpaginaempresa SingleOrDefault(Expression<Func<tblpaginaempresa, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblpaginaempresa single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblpaginaempresa, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblpaginaempresa, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblpaginaempresa> Find(Expression<Func<tblpaginaempresa, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblpaginaempresa> Find(Expression<Func<tblpaginaempresa, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblpaginaempresa> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblpaginaempresa> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblpaginaempresa> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblpaginaempresa> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblpaginaempresa> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblpaginaempresa> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina";
        }

        public object KeyValue()
        {
            return this.id_pagina;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblpaginaempresa)){
                tblpaginaempresa compare=(tblpaginaempresa)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina;
        public int id_pagina
        {
            get { return _id_pagina; }
            set
            {
                if(_id_pagina!=value){
                    _id_pagina=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblpaginaempresa, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblpaginaestruturaorganizacional table in the sm3 Database.
    /// </summary>
    public partial class tblpaginaestruturaorganizacional: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblpaginaestruturaorganizacional> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblpaginaestruturaorganizacional>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblpaginaestruturaorganizacional> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblpaginaestruturaorganizacional item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblpaginaestruturaorganizacional item=new tblpaginaestruturaorganizacional();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblpaginaestruturaorganizacional> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblpaginaestruturaorganizacional(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblpaginaestruturaorganizacional.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginaestruturaorganizacional>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblpaginaestruturaorganizacional(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblpaginaestruturaorganizacional(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblpaginaestruturaorganizacional> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblpaginaestruturaorganizacional> _repo;
            
            if(db.TestMode){
                tblpaginaestruturaorganizacional.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginaestruturaorganizacional>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblpaginaestruturaorganizacional> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblpaginaestruturaorganizacional SingleOrDefault(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblpaginaestruturaorganizacional single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblpaginaestruturaorganizacional SingleOrDefault(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblpaginaestruturaorganizacional single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblpaginaestruturaorganizacional> Find(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblpaginaestruturaorganizacional> Find(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblpaginaestruturaorganizacional> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblpaginaestruturaorganizacional> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblpaginaestruturaorganizacional> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblpaginaestruturaorganizacional> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblpaginaestruturaorganizacional> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblpaginaestruturaorganizacional> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina_estrutura";
        }

        public object KeyValue()
        {
            return this.id_pagina_estrutura;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblpaginaestruturaorganizacional)){
                tblpaginaestruturaorganizacional compare=(tblpaginaestruturaorganizacional)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina_estrutura;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina_estrutura";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina_estrutura;
        public int id_pagina_estrutura
        {
            get { return _id_pagina_estrutura; }
            set
            {
                if(_id_pagina_estrutura!=value){
                    _id_pagina_estrutura=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina_estrutura");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblpaginaestruturaorganizacional, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblpaginamissao table in the sm3 Database.
    /// </summary>
    public partial class tblpaginamissao: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblpaginamissao> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblpaginamissao>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblpaginamissao> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblpaginamissao item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblpaginamissao item=new tblpaginamissao();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblpaginamissao> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblpaginamissao(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblpaginamissao.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginamissao>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblpaginamissao(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblpaginamissao(Expression<Func<tblpaginamissao, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblpaginamissao> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblpaginamissao> _repo;
            
            if(db.TestMode){
                tblpaginamissao.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginamissao>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblpaginamissao> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblpaginamissao SingleOrDefault(Expression<Func<tblpaginamissao, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblpaginamissao single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblpaginamissao SingleOrDefault(Expression<Func<tblpaginamissao, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblpaginamissao single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblpaginamissao, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblpaginamissao, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblpaginamissao> Find(Expression<Func<tblpaginamissao, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblpaginamissao> Find(Expression<Func<tblpaginamissao, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblpaginamissao> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblpaginamissao> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblpaginamissao> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblpaginamissao> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblpaginamissao> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblpaginamissao> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina_missao";
        }

        public object KeyValue()
        {
            return this.id_pagina_missao;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblpaginamissao)){
                tblpaginamissao compare=(tblpaginamissao)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina_missao;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina_missao";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina_missao;
        public int id_pagina_missao
        {
            get { return _id_pagina_missao; }
            set
            {
                if(_id_pagina_missao!=value){
                    _id_pagina_missao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina_missao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblpaginamissao, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblpaginaprofissionais table in the sm3 Database.
    /// </summary>
    public partial class tblpaginaprofissionai: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblpaginaprofissionai> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblpaginaprofissionai>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblpaginaprofissionai> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblpaginaprofissionai item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblpaginaprofissionai item=new tblpaginaprofissionai();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblpaginaprofissionai> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblpaginaprofissionai(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblpaginaprofissionai.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginaprofissionai>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblpaginaprofissionai(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblpaginaprofissionai(Expression<Func<tblpaginaprofissionai, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblpaginaprofissionai> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblpaginaprofissionai> _repo;
            
            if(db.TestMode){
                tblpaginaprofissionai.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginaprofissionai>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblpaginaprofissionai> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblpaginaprofissionai SingleOrDefault(Expression<Func<tblpaginaprofissionai, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblpaginaprofissionai single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblpaginaprofissionai SingleOrDefault(Expression<Func<tblpaginaprofissionai, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblpaginaprofissionai single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblpaginaprofissionai, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblpaginaprofissionai, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblpaginaprofissionai> Find(Expression<Func<tblpaginaprofissionai, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblpaginaprofissionai> Find(Expression<Func<tblpaginaprofissionai, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblpaginaprofissionai> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblpaginaprofissionai> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblpaginaprofissionai> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblpaginaprofissionai> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblpaginaprofissionai> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblpaginaprofissionai> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina_profissionais";
        }

        public object KeyValue()
        {
            return this.id_pagina_profissionais;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblpaginaprofissionai)){
                tblpaginaprofissionai compare=(tblpaginaprofissionai)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina_profissionais;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina_profissionais";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina_profissionais;
        public int id_pagina_profissionais
        {
            get { return _id_pagina_profissionais; }
            set
            {
                if(_id_pagina_profissionais!=value){
                    _id_pagina_profissionais=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina_profissionais");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblpaginaprofissionai, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblpaginavisao table in the sm3 Database.
    /// </summary>
    public partial class tblpaginavisao: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblpaginavisao> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblpaginavisao>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblpaginavisao> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblpaginavisao item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblpaginavisao item=new tblpaginavisao();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblpaginavisao> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblpaginavisao(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblpaginavisao.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginavisao>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblpaginavisao(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblpaginavisao(Expression<Func<tblpaginavisao, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblpaginavisao> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblpaginavisao> _repo;
            
            if(db.TestMode){
                tblpaginavisao.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblpaginavisao>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblpaginavisao> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblpaginavisao SingleOrDefault(Expression<Func<tblpaginavisao, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblpaginavisao single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblpaginavisao SingleOrDefault(Expression<Func<tblpaginavisao, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblpaginavisao single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblpaginavisao, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblpaginavisao, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblpaginavisao> Find(Expression<Func<tblpaginavisao, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblpaginavisao> Find(Expression<Func<tblpaginavisao, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblpaginavisao> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblpaginavisao> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblpaginavisao> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblpaginavisao> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblpaginavisao> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblpaginavisao> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina_visao";
        }

        public object KeyValue()
        {
            return this.id_pagina_visao;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblpaginavisao)){
                tblpaginavisao compare=(tblpaginavisao)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina_visao;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina_visao";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina_visao;
        public int id_pagina_visao
        {
            get { return _id_pagina_visao; }
            set
            {
                if(_id_pagina_visao!=value){
                    _id_pagina_visao=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina_visao");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblpaginavisao, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblparametros table in the sm3 Database.
    /// </summary>
    public partial class tblparametro: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblparametro> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblparametro>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblparametro> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblparametro item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblparametro item=new tblparametro();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblparametro> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblparametro(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblparametro.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblparametro>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblparametro(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblparametro(Expression<Func<tblparametro, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblparametro> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblparametro> _repo;
            
            if(db.TestMode){
                tblparametro.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblparametro>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblparametro> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblparametro SingleOrDefault(Expression<Func<tblparametro, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblparametro single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblparametro SingleOrDefault(Expression<Func<tblparametro, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblparametro single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblparametro, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblparametro, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblparametro> Find(Expression<Func<tblparametro, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblparametro> Find(Expression<Func<tblparametro, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblparametro> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblparametro> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblparametro> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblparametro> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblparametro> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblparametro> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_parametro";
        }

        public object KeyValue()
        {
            return this.id_parametro;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.chave.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblparametro)){
                tblparametro compare=(tblparametro)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_parametro;
        }
        
        public string DescriptorValue()
        {
                            return this.chave.ToString();
                    }

        public string DescriptorColumn() {
            return "chave";
        }
        public static string GetKeyColumn()
        {
            return "id_parametro";
        }        
        public static string GetDescriptorColumn()
        {
            return "chave";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_parametro;
        public int id_parametro
        {
            get { return _id_parametro; }
            set
            {
                if(_id_parametro!=value){
                    _id_parametro=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_parametro");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _chave;
        public string chave
        {
            get { return _chave; }
            set
            {
                if(_chave!=value){
                    _chave=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="chave");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _valor;
        public string valor
        {
            get { return _valor; }
            set
            {
                if(_valor!=value){
                    _valor=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="valor");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _title;
        public string title
        {
            get { return _title; }
            set
            {
                if(_title!=value){
                    _title=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="title");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _src;
        public string src
        {
            get { return _src; }
            set
            {
                if(_src!=value){
                    _src=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="src");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _is_habilitado;
        public bool? is_habilitado
        {
            get { return _is_habilitado; }
            set
            {
                if(_is_habilitado!=value){
                    _is_habilitado=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="is_habilitado");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblparametro, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the tblvalores table in the sm3 Database.
    /// </summary>
    public partial class tblvalore: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<tblvalore> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<tblvalore>(new Sme.Data.sm3DB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<tblvalore> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(tblvalore item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                tblvalore item=new tblvalore();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<tblvalore> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Sme.Data.sm3DB _db;
        public tblvalore(string connectionString, string providerName) {

            _db=new Sme.Data.sm3DB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                tblvalore.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblvalore>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public tblvalore(){
             _db=new Sme.Data.sm3DB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public tblvalore(Expression<Func<tblvalore, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<tblvalore> GetRepo(string connectionString, string providerName){
            Sme.Data.sm3DB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Sme.Data.sm3DB();
            }else{
                db=new Sme.Data.sm3DB(connectionString, providerName);
            }
            IRepository<tblvalore> _repo;
            
            if(db.TestMode){
                tblvalore.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<tblvalore>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<tblvalore> GetRepo(){
            return GetRepo("","");
        }
        
        public static tblvalore SingleOrDefault(Expression<Func<tblvalore, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            tblvalore single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static tblvalore SingleOrDefault(Expression<Func<tblvalore, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            tblvalore single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<tblvalore, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<tblvalore, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<tblvalore> Find(Expression<Func<tblvalore, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<tblvalore> Find(Expression<Func<tblvalore, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<tblvalore> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<tblvalore> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<tblvalore> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<tblvalore> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<tblvalore> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<tblvalore> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "id_pagina_valores";
        }

        public object KeyValue()
        {
            return this.id_pagina_valores;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.conteudo.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(tblvalore)){
                tblvalore compare=(tblvalore)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.id_pagina_valores;
        }
        
        public string DescriptorValue()
        {
                            return this.conteudo.ToString();
                    }

        public string DescriptorColumn() {
            return "conteudo";
        }
        public static string GetKeyColumn()
        {
            return "id_pagina_valores";
        }        
        public static string GetDescriptorColumn()
        {
            return "conteudo";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _id_pagina_valores;
        public int id_pagina_valores
        {
            get { return _id_pagina_valores; }
            set
            {
                if(_id_pagina_valores!=value){
                    _id_pagina_valores=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_pagina_valores");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _id_album_foto;
        public int? id_album_foto
        {
            get { return _id_album_foto; }
            set
            {
                if(_id_album_foto!=value){
                    _id_album_foto=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="id_album_foto");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _conteudo;
        public string conteudo
        {
            get { return _conteudo; }
            set
            {
                if(_conteudo!=value){
                    _conteudo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="conteudo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<tblvalore, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}

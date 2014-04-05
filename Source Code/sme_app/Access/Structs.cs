


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace Sme.Data {
	
        /// <summary>
        /// Table: tblBanners
        /// Primary Key: id_banner
        /// </summary>

        public class tblBannersTable: DatabaseTable {
            
            public tblBannersTable(IDataProvider provider):base("tblBanners",provider){
                ClassName = "tblBanner";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_banner", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("nome", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("path", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 300
                });

                Columns.Add(new DatabaseColumn("nome_arquivo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("dt_cadastro", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("is_ativo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("path_thumb", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 300
                });

                Columns.Add(new DatabaseColumn("nome_arquivo_thumb", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("descricao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });
                    
                
                
            }

            public IColumn id_banner{
                get{
                    return this.GetColumn("id_banner");
                }
            }
				
   			public static string id_bannerColumn{
			      get{
        			return "id_banner";
      			}
		    }
            
            public IColumn nome{
                get{
                    return this.GetColumn("nome");
                }
            }
				
   			public static string nomeColumn{
			      get{
        			return "nome";
      			}
		    }
            
            public IColumn path{
                get{
                    return this.GetColumn("path");
                }
            }
				
   			public static string pathColumn{
			      get{
        			return "path";
      			}
		    }
            
            public IColumn nome_arquivo{
                get{
                    return this.GetColumn("nome_arquivo");
                }
            }
				
   			public static string nome_arquivoColumn{
			      get{
        			return "nome_arquivo";
      			}
		    }
            
            public IColumn dt_cadastro{
                get{
                    return this.GetColumn("dt_cadastro");
                }
            }
				
   			public static string dt_cadastroColumn{
			      get{
        			return "dt_cadastro";
      			}
		    }
            
            public IColumn is_ativo{
                get{
                    return this.GetColumn("is_ativo");
                }
            }
				
   			public static string is_ativoColumn{
			      get{
        			return "is_ativo";
      			}
		    }
            
            public IColumn path_thumb{
                get{
                    return this.GetColumn("path_thumb");
                }
            }
				
   			public static string path_thumbColumn{
			      get{
        			return "path_thumb";
      			}
		    }
            
            public IColumn nome_arquivo_thumb{
                get{
                    return this.GetColumn("nome_arquivo_thumb");
                }
            }
				
   			public static string nome_arquivo_thumbColumn{
			      get{
        			return "nome_arquivo_thumb";
      			}
		    }
            
            public IColumn descricao{
                get{
                    return this.GetColumn("descricao");
                }
            }
				
   			public static string descricaoColumn{
			      get{
        			return "descricao";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblalbumfotos
        /// Primary Key: id_album_foto
        /// </summary>

        public class tblalbumfotosTable: DatabaseTable {
            
            public tblalbumfotosTable(IDataProvider provider):base("tblalbumfotos",provider){
                ClassName = "tblalbumfoto";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("nome", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("descricao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("is_ativo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("pagina_pai", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("capa_album_path", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("capa_album_file", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("foto_album_path", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("foto_album_file", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });
                    
                
                
            }

            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn nome{
                get{
                    return this.GetColumn("nome");
                }
            }
				
   			public static string nomeColumn{
			      get{
        			return "nome";
      			}
		    }
            
            public IColumn descricao{
                get{
                    return this.GetColumn("descricao");
                }
            }
				
   			public static string descricaoColumn{
			      get{
        			return "descricao";
      			}
		    }
            
            public IColumn is_ativo{
                get{
                    return this.GetColumn("is_ativo");
                }
            }
				
   			public static string is_ativoColumn{
			      get{
        			return "is_ativo";
      			}
		    }
            
            public IColumn pagina_pai{
                get{
                    return this.GetColumn("pagina_pai");
                }
            }
				
   			public static string pagina_paiColumn{
			      get{
        			return "pagina_pai";
      			}
		    }
            
            public IColumn capa_album_path{
                get{
                    return this.GetColumn("capa_album_path");
                }
            }
				
   			public static string capa_album_pathColumn{
			      get{
        			return "capa_album_path";
      			}
		    }
            
            public IColumn capa_album_file{
                get{
                    return this.GetColumn("capa_album_file");
                }
            }
				
   			public static string capa_album_fileColumn{
			      get{
        			return "capa_album_file";
      			}
		    }
            
            public IColumn foto_album_path{
                get{
                    return this.GetColumn("foto_album_path");
                }
            }
				
   			public static string foto_album_pathColumn{
			      get{
        			return "foto_album_path";
      			}
		    }
            
            public IColumn foto_album_file{
                get{
                    return this.GetColumn("foto_album_file");
                }
            }
				
   			public static string foto_album_fileColumn{
			      get{
        			return "foto_album_file";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tbldicas
        /// Primary Key: id_dica
        /// </summary>

        public class tbldicasTable: DatabaseTable {
            
            public tbldicasTable(IDataProvider provider):base("tbldicas",provider){
                ClassName = "tbldica";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_dica", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("titulo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("descricao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 150
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("fonte", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("dt_criacao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id_dica{
                get{
                    return this.GetColumn("id_dica");
                }
            }
				
   			public static string id_dicaColumn{
			      get{
        			return "id_dica";
      			}
		    }
            
            public IColumn titulo{
                get{
                    return this.GetColumn("titulo");
                }
            }
				
   			public static string tituloColumn{
			      get{
        			return "titulo";
      			}
		    }
            
            public IColumn descricao{
                get{
                    return this.GetColumn("descricao");
                }
            }
				
   			public static string descricaoColumn{
			      get{
        			return "descricao";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
            public IColumn fonte{
                get{
                    return this.GetColumn("fonte");
                }
            }
				
   			public static string fonteColumn{
			      get{
        			return "fonte";
      			}
		    }
            
            public IColumn dt_criacao{
                get{
                    return this.GetColumn("dt_criacao");
                }
            }
				
   			public static string dt_criacaoColumn{
			      get{
        			return "dt_criacao";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblfotos
        /// Primary Key: id_foto
        /// </summary>

        public class tblfotosTable: DatabaseTable {
            
            public tblfotosTable(IDataProvider provider):base("tblfotos",provider){
                ClassName = "tblfoto";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_foto", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("nome", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("descricao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("path", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 150
                });

                Columns.Add(new DatabaseColumn("arquivo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("path_thumb", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("arquivo_thumb", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });
                    
                
                
            }

            public IColumn id_foto{
                get{
                    return this.GetColumn("id_foto");
                }
            }
				
   			public static string id_fotoColumn{
			      get{
        			return "id_foto";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn nome{
                get{
                    return this.GetColumn("nome");
                }
            }
				
   			public static string nomeColumn{
			      get{
        			return "nome";
      			}
		    }
            
            public IColumn descricao{
                get{
                    return this.GetColumn("descricao");
                }
            }
				
   			public static string descricaoColumn{
			      get{
        			return "descricao";
      			}
		    }
            
            public IColumn path{
                get{
                    return this.GetColumn("path");
                }
            }
				
   			public static string pathColumn{
			      get{
        			return "path";
      			}
		    }
            
            public IColumn arquivo{
                get{
                    return this.GetColumn("arquivo");
                }
            }
				
   			public static string arquivoColumn{
			      get{
        			return "arquivo";
      			}
		    }
            
            public IColumn path_thumb{
                get{
                    return this.GetColumn("path_thumb");
                }
            }
				
   			public static string path_thumbColumn{
			      get{
        			return "path_thumb";
      			}
		    }
            
            public IColumn arquivo_thumb{
                get{
                    return this.GetColumn("arquivo_thumb");
                }
            }
				
   			public static string arquivo_thumbColumn{
			      get{
        			return "arquivo_thumb";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tbllogin
        /// Primary Key: id_login
        /// </summary>

        public class tblloginTable: DatabaseTable {
            
            public tblloginTable(IDataProvider provider):base("tbllogin",provider){
                ClassName = "tbllogin";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_login", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("login", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("senha", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("nome", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });
                    
                
                
            }

            public IColumn id_login{
                get{
                    return this.GetColumn("id_login");
                }
            }
				
   			public static string id_loginColumn{
			      get{
        			return "id_login";
      			}
		    }
            
            public IColumn login{
                get{
                    return this.GetColumn("login");
                }
            }
				
   			public static string loginColumn{
			      get{
        			return "login";
      			}
		    }
            
            public IColumn senha{
                get{
                    return this.GetColumn("senha");
                }
            }
				
   			public static string senhaColumn{
			      get{
        			return "senha";
      			}
		    }
            
            public IColumn nome{
                get{
                    return this.GetColumn("nome");
                }
            }
				
   			public static string nomeColumn{
			      get{
        			return "nome";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblnossosservicos
        /// Primary Key: id_pagina_servicos
        /// </summary>

        public class tblnossosservicosTable: DatabaseTable {
            
            public tblnossosservicosTable(IDataProvider provider):base("tblnossosservicos",provider){
                ClassName = "tblnossosservico";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina_servicos", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina_servicos{
                get{
                    return this.GetColumn("id_pagina_servicos");
                }
            }
				
   			public static string id_pagina_servicosColumn{
			      get{
        			return "id_pagina_servicos";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblnoticias
        /// Primary Key: id_noticia
        /// </summary>

        public class tblnoticiasTable: DatabaseTable {
            
            public tblnoticiasTable(IDataProvider provider):base("tblnoticias",provider){
                ClassName = "tblnoticia";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_noticia", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("titulo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("descricao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 150
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });

                Columns.Add(new DatabaseColumn("fonte", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("dt_criacao", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id_noticia{
                get{
                    return this.GetColumn("id_noticia");
                }
            }
				
   			public static string id_noticiaColumn{
			      get{
        			return "id_noticia";
      			}
		    }
            
            public IColumn titulo{
                get{
                    return this.GetColumn("titulo");
                }
            }
				
   			public static string tituloColumn{
			      get{
        			return "titulo";
      			}
		    }
            
            public IColumn descricao{
                get{
                    return this.GetColumn("descricao");
                }
            }
				
   			public static string descricaoColumn{
			      get{
        			return "descricao";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
            public IColumn fonte{
                get{
                    return this.GetColumn("fonte");
                }
            }
				
   			public static string fonteColumn{
			      get{
        			return "fonte";
      			}
		    }
            
            public IColumn dt_criacao{
                get{
                    return this.GetColumn("dt_criacao");
                }
            }
				
   			public static string dt_criacaoColumn{
			      get{
        			return "dt_criacao";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblpaginaempresa
        /// Primary Key: id_pagina
        /// </summary>

        public class tblpaginaempresaTable: DatabaseTable {
            
            public tblpaginaempresaTable(IDataProvider provider):base("tblpaginaempresa",provider){
                ClassName = "tblpaginaempresa";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina{
                get{
                    return this.GetColumn("id_pagina");
                }
            }
				
   			public static string id_paginaColumn{
			      get{
        			return "id_pagina";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblpaginaestruturaorganizacional
        /// Primary Key: id_pagina_estrutura
        /// </summary>

        public class tblpaginaestruturaorganizacionalTable: DatabaseTable {
            
            public tblpaginaestruturaorganizacionalTable(IDataProvider provider):base("tblpaginaestruturaorganizacional",provider){
                ClassName = "tblpaginaestruturaorganizacional";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina_estrutura", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina_estrutura{
                get{
                    return this.GetColumn("id_pagina_estrutura");
                }
            }
				
   			public static string id_pagina_estruturaColumn{
			      get{
        			return "id_pagina_estrutura";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblpaginamissao
        /// Primary Key: id_pagina_missao
        /// </summary>

        public class tblpaginamissaoTable: DatabaseTable {
            
            public tblpaginamissaoTable(IDataProvider provider):base("tblpaginamissao",provider){
                ClassName = "tblpaginamissao";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina_missao", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina_missao{
                get{
                    return this.GetColumn("id_pagina_missao");
                }
            }
				
   			public static string id_pagina_missaoColumn{
			      get{
        			return "id_pagina_missao";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblpaginaprofissionais
        /// Primary Key: id_pagina_profissionais
        /// </summary>

        public class tblpaginaprofissionaisTable: DatabaseTable {
            
            public tblpaginaprofissionaisTable(IDataProvider provider):base("tblpaginaprofissionais",provider){
                ClassName = "tblpaginaprofissionai";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina_profissionais", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina_profissionais{
                get{
                    return this.GetColumn("id_pagina_profissionais");
                }
            }
				
   			public static string id_pagina_profissionaisColumn{
			      get{
        			return "id_pagina_profissionais";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblpaginavisao
        /// Primary Key: id_pagina_visao
        /// </summary>

        public class tblpaginavisaoTable: DatabaseTable {
            
            public tblpaginavisaoTable(IDataProvider provider):base("tblpaginavisao",provider){
                ClassName = "tblpaginavisao";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina_visao", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina_visao{
                get{
                    return this.GetColumn("id_pagina_visao");
                }
            }
				
   			public static string id_pagina_visaoColumn{
			      get{
        			return "id_pagina_visao";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblparametros
        /// Primary Key: id_parametro
        /// </summary>

        public class tblparametrosTable: DatabaseTable {
            
            public tblparametrosTable(IDataProvider provider):base("tblparametros",provider){
                ClassName = "tblparametro";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_parametro", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("chave", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("valor", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("title", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("src", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("is_habilitado", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn id_parametro{
                get{
                    return this.GetColumn("id_parametro");
                }
            }
				
   			public static string id_parametroColumn{
			      get{
        			return "id_parametro";
      			}
		    }
            
            public IColumn chave{
                get{
                    return this.GetColumn("chave");
                }
            }
				
   			public static string chaveColumn{
			      get{
        			return "chave";
      			}
		    }
            
            public IColumn valor{
                get{
                    return this.GetColumn("valor");
                }
            }
				
   			public static string valorColumn{
			      get{
        			return "valor";
      			}
		    }
            
            public IColumn title{
                get{
                    return this.GetColumn("title");
                }
            }
				
   			public static string titleColumn{
			      get{
        			return "title";
      			}
		    }
            
            public IColumn src{
                get{
                    return this.GetColumn("src");
                }
            }
				
   			public static string srcColumn{
			      get{
        			return "src";
      			}
		    }
            
            public IColumn is_habilitado{
                get{
                    return this.GetColumn("is_habilitado");
                }
            }
				
   			public static string is_habilitadoColumn{
			      get{
        			return "is_habilitado";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: tblvalores
        /// Primary Key: id_pagina_valores
        /// </summary>

        public class tblvaloresTable: DatabaseTable {
            
            public tblvaloresTable(IDataProvider provider):base("tblvalores",provider){
                ClassName = "tblvalore";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("id_pagina_valores", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("id_album_foto", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("conteudo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 65535
                });
                    
                
                
            }

            public IColumn id_pagina_valores{
                get{
                    return this.GetColumn("id_pagina_valores");
                }
            }
				
   			public static string id_pagina_valoresColumn{
			      get{
        			return "id_pagina_valores";
      			}
		    }
            
            public IColumn id_album_foto{
                get{
                    return this.GetColumn("id_album_foto");
                }
            }
				
   			public static string id_album_fotoColumn{
			      get{
        			return "id_album_foto";
      			}
		    }
            
            public IColumn conteudo{
                get{
                    return this.GetColumn("conteudo");
                }
            }
				
   			public static string conteudoColumn{
			      get{
        			return "conteudo";
      			}
		    }
            
                    
        }
        
}
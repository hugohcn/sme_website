using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;

namespace Access
{
    public class AlbumFotosAC
    {
        public void InserirAbum(string titulo, string descricao, string pagina, string capaAlbumPath, string capaAlbumFile, string fotoAlbumPath, string fotoAlbumFile)
        {
            try
            {
                tblalbumfoto album = new tblalbumfoto();
                album.SetIsNew(true);
                album.nome = titulo;
                album.descricao = descricao;
                album.is_ativo = true;
                album.pagina_pai = pagina;
                album.capa_album_path = capaAlbumPath;
                album.capa_album_file = capaAlbumFile;
                album.foto_album_path = fotoAlbumPath;
                album.foto_album_file = fotoAlbumFile;
                
                album.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<tblalbumfoto> RecuperarFotosPagina(String pagina)
        {
            try
            {
                return tblalbumfoto.Find(x => x.pagina_pai.Equals(pagina));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<tblfoto> RecuperarFotosPagina(int idAlbum)
        {
            try
            {
                return tblfoto.Find(x => x.id_album_foto == idAlbum);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SalvarFoto(int idAlbum, string titulo, string descricao, string filePath, string fileName, string thumbPath, string thumbName)
        {
            try
            {
                tblfoto foto = new tblfoto();
                foto.SetIsNew(true);
                foto.id_album_foto = idAlbum;
                foto.nome = titulo;
                foto.descricao = descricao;
                foto.path = filePath;
                foto.arquivo = fileName;
                foto.arquivo_thumb = thumbName;
                foto.path_thumb = thumbPath;
                
                foto.Save();
                
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
        public void DeletarFoto(string idFoto)
        {
            try
            {
                tblfoto foto = new tblfoto();
                foto.SetKeyValue(idFoto);
                
                foto.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void DeletarAlbumFotos(string idAlbum)
        {
            try
            {
                //Antes de apagar o album, deleta todas as fotos...
                IList<tblfoto> fotos = tblfoto.Find(x => x.id_album_foto == Convert.ToInt32(idAlbum));

                foreach (tblfoto x in fotos)
                {
                    //Deleta todas as fotos do album
                    x.Delete();
                }
            
                //Após deletar as fotos, deleta-se o album.
                tblalbumfoto album = new tblalbumfoto();
                album.SetIsNew(false);
                album.SetIsLoaded(true);
                album.SetKeyValue(idAlbum);
                
                album.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

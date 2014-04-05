using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Access;
using Sme.Data;

namespace Business
{
    public class AlbumFotosBU
    {
        public void InserirAbum(string titulo, string descricao, string pagina, string capaAlbumPath, string capaAlbumFile, string fotoAlbumPath, string fotoAlbumFile)
        {
            try
            {
                new AlbumFotosAC().InserirAbum(titulo, descricao, pagina, capaAlbumPath, capaAlbumFile, fotoAlbumPath, fotoAlbumFile);
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
                return new AlbumFotosAC().RecuperarFotosPagina(pagina);
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
                return new AlbumFotosAC().RecuperarFotosPagina(idAlbum);
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
                new AlbumFotosAC().SalvarFoto(idAlbum, titulo, descricao, filePath, fileName, thumbPath, thumbName);
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
                new AlbumFotosAC().DeletarFoto(idFoto);
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
                new AlbumFotosAC().DeletarAlbumFotos(idAlbum);  
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

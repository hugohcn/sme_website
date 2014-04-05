using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using SubSonic.Schema;

namespace Access
{
    public class PaginaConteudoCA
    {
        public void InserirConteudoPagina(string pagina, string conteudo)
        {
            try
            {
                switch (pagina)
                {
                    case ("empresa"):
                        {
                            tblpaginaempresa pag = new tblpaginaempresa();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }

                    case ("nossamissao"):
                        {
                            tblpaginamissao pag = new tblpaginamissao();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }

                    case ("visao"):
                        {
                            tblpaginavisao pag = new tblpaginavisao();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }

                    case ("valores"):
                        {
                            tblvalore pag = new tblvalore();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }

                    case ("est_organizacional"):
                        {
                            tblpaginaestruturaorganizacional pag = new tblpaginaestruturaorganizacional();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }
                    case ("ns_servicos"):
                        {
                            tblnossosservico pag = new tblnossosservico();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }

                    case ("prof_modelos"):
                        {
                            tblpaginaprofissionai pag = new tblpaginaprofissionai();
                            pag.SetIsNew(true);
                            pag.conteudo = conteudo;

                            pag.Save();
                            break;
                        }
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        public object RetornaConteudoPagina(string pagina)
        {
            try
            {
                if (pagina == "empresa")
                {
                    return tblpaginaempresa.SingleOrDefault(x => x.id_pagina > -1);
                }
                else if (pagina == "nossamissao")
                {
                    return tblpaginamissao.SingleOrDefault(x => x.id_pagina_missao > -1);
                }
                else if (pagina == "visao")
                {
                    return tblpaginavisao.SingleOrDefault(x => x.id_pagina_visao > -1);
                }
                else if (pagina == "valores")
                {
                    return tblvalore.SingleOrDefault(x => x.id_pagina_valores > -1);
                }
                else if (pagina == "est_organizacional")
                {
                    return tblpaginaestruturaorganizacional.SingleOrDefault(x => x.id_pagina_estrutura > -1);
                }
                else if (pagina == "ns_servicos")
                {
                    return tblnossosservico.SingleOrDefault(x => x.id_pagina_servicos > -1);
                }
                else
                    return tblpaginaprofissionai.SingleOrDefault(x => x.id_pagina_profissionais > -1);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        public void AtualizarConteudoPagina(string pagina, string conteudo)
        {
            try
            {
                if (pagina == "empresa")
                {
                    tblpaginaempresa pag = new tblpaginaempresa();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;

                    pag.Update();
                }
                else if (pagina == "nossamissao")
                {
                    tblpaginamissao pag = new tblpaginamissao();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;
                    pag.Update();
                }
                else if (pagina == "visao")
                {
                    tblpaginavisao pag = new tblpaginavisao();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;
                    pag.Update();
                }
                else if (pagina == "valores")
                {
                    tblvalore pag = new tblvalore();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;
                    pag.Update();
                }
                else if (pagina == "est_organizacional")
                {
                    tblpaginaestruturaorganizacional pag = new tblpaginaestruturaorganizacional();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;
                    pag.Update();
                }
                else if (pagina == "ns_servicos")
                {
                    tblnossosservico pag = new tblnossosservico();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;
                    pag.Update();
                }
                else
                {
                    tblpaginaprofissionai pag = new tblpaginaprofissionai();
                    pag.SetIsLoaded(true);
                    pag.SetKeyValue(RetornaUltimoIdPagina(pagina));
                    pag.SetIsNew(false);
                    pag.conteudo = conteudo;
                    pag.Update();
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        public int RetornaUltimoIdPagina(string pagina)
        {
            if (pagina == "empresa")
            {
                tblpaginaempresa pag = tblpaginaempresa.SingleOrDefault(x => x.id_pagina > -1);
                return pag.id_pagina;
            }
            else if (pagina == "nossamissao")
            {
                tblpaginamissao pag = tblpaginamissao.SingleOrDefault(x => x.id_pagina_missao > -1);
                return pag.id_pagina_missao;
            }
            else if (pagina == "visao")
            {
                tblpaginavisao pag = tblpaginavisao.SingleOrDefault(x => x.id_pagina_visao > -1);
                return pag.id_pagina_visao;
            }
            else if (pagina == "valores")
            {
                tblvalore pag = tblvalore.SingleOrDefault(x => x.id_pagina_valores > -1);
                return pag.id_pagina_valores;
            }
            else if (pagina == "est_organizacional")
            {
                tblpaginaestruturaorganizacional pag = tblpaginaestruturaorganizacional.SingleOrDefault(x => x.id_pagina_estrutura > -1);
                return pag.id_pagina_estrutura;
            }
            else if (pagina == "ns_servicos")
            {
                tblnossosservico pag = tblnossosservico.SingleOrDefault(x => x.id_pagina_servicos > -1);
                return pag.id_pagina_servicos;
            }
            else
            {
                tblpaginaprofissionai pag = tblpaginaprofissionai.SingleOrDefault(x => x.id_pagina_profissionais > -1);
                return pag.id_pagina_profissionais;
            }

        }

    }
}

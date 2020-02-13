using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polivalencia.Controllers
{
    public class HabilitacaoController : Controller
    {
        Blc bl = new Blc();
        int Idhab = 0;

        // GET: Habilitacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaHabilitacao(int idfunc)
        {            
            ViewBag.Funcionario = bl.GeraListaFuncionario();
            ViewData["IdFunc"] = idfunc.ToString();
            ViewData["NomeFuncionario"] = bl.RetornaNomeFuncionario(idfunc); 

            List<Habilitacao> lsthab = bl.GeraListaHabilitacao(idfunc);
            return View(lsthab);
        }

        public ActionResult Addhabilitacao(int idfunc,int idhab)
        {
            @ViewData["Idfunc"] = idfunc;
            @ViewData["Idhab"]  = idhab;
            ViewData["NomeFuncionario"] = bl.RetornaNomeFuncionario(idfunc);

            List<PostoTrabalho> lstposto = bl.GeraListaPostoTrabalho();

            ViewBag.LstPt = lstposto;

            if (idhab > 0)
            {
               
                Habilitacao hab = bl.RetornaHabilitacao(idhab);
                return View(hab);
               
            }else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addhabilitacao(Habilitacao hab,int idhab)
        {
            if (ModelState.IsValid)
            {
                bl.InsereHabilitacao(hab);
                ViewData["Message"] = "Registro Cadastrado!";
            }
            return View();
        }

        public ActionResult DelHabilitacao(int idhab, int idfunc)
        {
            ViewData["IdFunc"] = idfunc;
            Idhab = idhab;
            Habilitacao hab = bl.RetornaHabilitacao(idhab);
            return View(hab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DelHabilitacao(Habilitacao hab, int idfunc)
        {
            ViewData["IdFunc"] = idfunc;
            bl.Deletahabilitacao(hab.Id);
            ViewData["Message"] = "Registro Excluido!";
            return View();
        }
    }
}
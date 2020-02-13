using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace Polivalencia.Controllers
{
    public class FuncionarioController : Controller
    {
        int Idfunc = 0;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaFuncionario()
        {
            Blc bl = new Blc();
            List<Funcionario> lstfunc = bl.GeraListaFuncionario();
            return View(lstfunc);
        }

        public ActionResult AddFuncionario(int idfunc)
        {
            @ViewData["Idfunc"] = idfunc;
            if (idfunc > 0)
            {
                Idfunc = idfunc;
                Blc bl = new Blc();
                Funcionario func = bl.RetornaFuncionario(idfunc);
                return View(func);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(Funcionario func)
        {
            if (ModelState.IsValid)
            {
                if (Idfunc > 0)
                {
                    ViewData["Message"] = "Registro Cadastrado!";
                }
                else
                {
                    ViewData["Message"] = "Registro Editado!";
                }
            }
            return View("AddFuncionario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DelFuncionario(Funcionario func)
        {
            ViewData["Message"] = "Registro Excluido!";
            return View();
        }

        public ActionResult DelFuncionario(int idfunc)
        {
            Idfunc = idfunc;
            Blc bl = new Blc();
            Funcionario func = bl.RetornaFuncionario(idfunc);
            return View(func);
        }

    }
}
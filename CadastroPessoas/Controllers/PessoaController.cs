using CadastroPessoas.Models;
using CadastroPessoas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Listar()
        {
            using(Conexao db = new Conexao())
            {
                List<Pessoa> pessoasModels = db.Pessoa.ToList();
                List<PessoaViewModel> pessoasVms = new List<PessoaViewModel>();

                foreach (Pessoa item in pessoasModels)
                {
                    PessoaViewModel pessoaVm = new PessoaViewModel();
                    pessoaVm.Nome = item.Nome;
                    pessoaVm.DataNascimento = item.DataNascimento;
                    pessoaVm.Email = item.Email;

                    pessoasVms.Add(pessoaVm);
                }
                       return View(pessoasVms); 
            }
        }

        [HttpPost]
        public ActionResult CadastrarPost(PessoaViewModel dados)
        {  
            using (Conexao db = new Conexao())
            {
                dados.TratarDados();
                dados.Validar();

                Pessoa model = new Pessoa();
                model.Nome = dados.Nome.Hash();
                model.DataNascimento = dados.DataNascimento.Value;
                model.Sexo = dados.Sexo.Hash();
                model.EstadoCivil = dados.EstadoCivil.Hash();
                model.CPF = dados.CPF.Hash();
                model.CEP = dados.CEP.Hash();
                model.Endereco = dados.Endereco.Hash();
                model.Numero = dados.Numero.Hash();
                model.Complemento = dados.Complemento.Hash();
                model.Bairro = dados.Bairro.Hash();
                model.Cidade = dados.Cidade.Hash();
                model.UF = dados.UF.Hash();
                model.Email = dados.Email.Hash();
                model.Senha = dados.Senha.Hash();
                model.Senhac = dados.Senhac.Hash();
                model.Celular = dados.Celular.Hash();

                db.Pessoa.Add(model);
                db.SaveChanges();
            }

            return RedirectToAction("Cadastrar");
        }
    }
}
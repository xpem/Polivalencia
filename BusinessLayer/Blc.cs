using DataAcessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Blc
    {
        readonly alc alc = new alc();

        /// <summary>
        /// gera uma lista de exemplo
        /// </summary>
        /// <returns></returns>
        public List<Funcionario> GeraListaFuncionario()
        {
            DataTable dt = alc.consultar_tabela("select * from Funcionario");

            List<Funcionario> funcionarios = new List<Funcionario>();
            foreach (DataRow dr in dt.Rows)
            {
                Funcionario funcionario = new Funcionario()
                {
                    Nome = dr["nome"].ToString(),
                    Cidade = dr["cidade"].ToString(),
                    DtNascimento = Convert.ToDateTime(dr["dtnascimento"].ToString()),
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Telefone = dr["telefone"].ToString()
                };
                funcionarios.Add(funcionario);
            }
            return funcionarios;
        }


        public string RetornaNomeFuncionario(int idfunc)
        {
            return alc.consultar_string($"select nome from funcionario where id = {idfunc}");
        }

        public Funcionario RetornaFuncionario(int idfunc)
        {
            DataRow dr = alc.consultar_tabela($"select id,nome,cidade,dtnascimento,telefone from funcionario where id = {idfunc}").Rows[0];
            Funcionario funcionario = new Funcionario()
            {
                Nome = dr["nome"].ToString(),
                Cidade = dr["cidade"].ToString(),
                DtNascimento = Convert.ToDateTime(dr["dtnascimento"].ToString()),
                Id = Convert.ToInt32(dr["id"].ToString()),
                Telefone = dr["telefone"].ToString()
            };
            return funcionario;
        }

        public List<PostoTrabalho> GeraListaPostoTrabalho()
        {
            DataTable dt = alc.consultar_tabela("select id,nome from PostoTrabalho");

            List<PostoTrabalho> lstpostotrabalho = new List<PostoTrabalho>();

            foreach (DataRow dr in dt.Rows)
            {
                PostoTrabalho postotrab = new PostoTrabalho()
                {
                    Nome = dr["nome"].ToString(),
                    Id = Convert.ToInt32(dr["id"].ToString())
                };
                lstpostotrabalho.Add(postotrab);
            }
            return lstpostotrabalho;
        }

        public List<Habilitacao> GeraListaHabilitacao(int idfunc)
        {
            DataTable dt = alc.consultar_tabela($"select h.id,h.datavalidade,f.id as idfunc,p.id as idtrab,p.nome  as nomepostotrab from Habilitacao h inner join Funcionario f  on f.id = h.idfuncionario inner join PostoTrabalho p on p.id = h.idpostotrabalho where f.id = {idfunc}");

            List<Habilitacao> habitacoes = new List<Habilitacao>();

            foreach (DataRow dr in dt.Rows)
            {
                Habilitacao hab = new Habilitacao()
                {
                    DtValidade = Convert.ToDateTime(dr["datavalidade"].ToString()).ToString("dd/MM/yyyy"),
                    IdFunc = Convert.ToInt32(dr["idfunc"].ToString()),
                    IdPostoTrab = Convert.ToInt32(dr["idtrab"].ToString()),
                    NomePostoTrab = dr["nomepostotrab"].ToString(),
                    Id = Convert.ToInt32(dr["id"].ToString())

                };
                habitacoes.Add(hab);
            }
            return habitacoes;
        }

        public Habilitacao RetornaHabilitacao(int idhab)
        {
            DataRow dr = alc.consultar_tabela($"select h.id,h.datavalidade,f.id as idfunc,p.id as idtrab,p.nome as nomepostotrab,f.nome as nomefunc from Habilitacao h inner join Funcionario f  on f.id = h.idfuncionario inner join PostoTrabalho p on p.id = h.idpostotrabalho where h.id = {idhab}").Rows[0];
            Habilitacao hab = new Habilitacao()
            {
                DtValidade = Convert.ToDateTime(dr["datavalidade"].ToString()).ToString("dd/MM/yyyy"),
                IdFunc = Convert.ToInt32(dr["idfunc"].ToString()),
                IdPostoTrab = Convert.ToInt32(dr["idtrab"].ToString()),
                NomePostoTrab = dr["nomepostotrab"].ToString(),
                NomeFunc = dr["nomefunc"].ToString(),
                Id = Convert.ToInt32(dr["id"].ToString())

            };
            return hab;
        }

        public void InsereHabilitacao(Habilitacao hab)
        {
            string dtval = Convert.ToDateTime(hab.DtValidade).ToString("yyyy/MM/dd");
            alc.comando($"insert into Habilitacao(datavalidade, idfuncionario, idpostotrabalho) values(' {dtval}', '{hab.IdFunc}', {hab.IdPostoTrab})");
        }

        public void Deletahabilitacao(int hab)
        {
            alc.comando($"delete from Habilitacao where id = '{hab}'");
        }
    }
}

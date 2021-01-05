
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {

            using (Loja.Classes.Cliente cli2 = new Loja.Classes.Cliente(2))
            {
                cli2.Nome = "Zezinho";
            }

            //using (Cliente cli2 = new Cliente(2))
            //{

            //}


            //using (Cliente cli = new Cliente())
            //{
            //    cli.Codigo = 2;
            //    cli.Nome = "José";
            //    cli.Tipo = 2;
            //    cli.DataCadastro = new DateTime(2020, 10, 05);
            //}
            //    cli.Codigo = 1;
            //    cli.Nome = "genesys".PrimeiraMaiuscula();
            //    Console.WriteLine(cli.Nome);
            //    cli.Tipo = 1;
            //    cli.DataCadastro = new DateTime(2020,09,22);
            //    cli.Dispose();

            //}
            //catch (ConsoleApp1.Execoes.ExcecoesCliente.ValidacaoException ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}
            //  using (Cliente cli2 = new Cliente(5))
            //    {
            //    cli2.Nome = "Juanita";
            //    }


            //      Contato contato = new Contato();
            //   contato.Codigo = 2;
            //    contato.DadosContato = "(21)987-347368";
            //    contato.Tipo = "Telefone";

            //    Contato contato2 = new Contato();
            //    contato2.Codigo = 4;
            //    contato2.DadosContato = "genesys.merchan@gmail.com";
            //    contato2.Tipo = "E-mail";

            //     cli.Contatos = new List<Contato>();
            //       cli.Contatos.Add(contato);
            //   cli.Contatos.Add(contato2);

            //   foreach (Classes.Contato cont in cli.Contatos)
            //{
            //       Console.WriteLine(cont.DadosContato);
            //   }
            //Console.WriteLine(cli.Contatos.FirstOrDefault(x => x.Tipo == "E -mail").DadosContato);


        }
    }
}

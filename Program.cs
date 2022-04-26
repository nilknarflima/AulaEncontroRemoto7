using System;
using System.Threading;
using System.Collections.Generic;


namespace Encontro
{
    class Program
    {
        static void Main(string[] args)
        {

            List<PessoaFisica> ListaPF = new List<PessoaFisica>();
            Console.Clear(); // Limpar o terminal quando executar o códico.
            Console.ForegroundColor = ConsoleColor.DarkGreen; // mudar a cor da letra
            Console.BackgroundColor = ConsoleColor.DarkRed; //mudar a cor do fundo..
            Console.WriteLine(@$"
=====================================
|Bem vindo ao Sistema de Cadastro   |
|de Pessoa Física e Pessoa Juridica |
=====================================
");

            BarraCarregamento("Iniciando");



            string? respostaDoUsuário;

            do
            {
                Console.WriteLine(@$"
            
========================================
|     ESCOLHA UMA DAS OPÇÕES ABAIXO    |
|           PESSOA FISICA              |
|      1 - Cadastrar Pessoa Física     |
|      2 - Listar Pessoa Física        |
|      3 - Remover Pessoa Física       |
|           PESSOA JURÍDICA            |
|      1 - Cadastrar Pessoa Jurídica   |
|      2 - Listar Pessoa Jurídica      |
|      3 - Remover Pessoa Jurídica     |
|                                      |
|      0 - SAIR                        |
========================================
");
                respostaDoUsuário = Console.ReadLine();

                switch (respostaDoUsuário)
                {
                    case "1":

                        Endereco endPf = new Endereco();

                        Console.WriteLine("Digite seu Logradouro");
                        endPf.logradouro = Console.ReadLine();

                        Console.WriteLine("Digite o Número ");
                        endPf.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o complemento (Aperte o Enter para vazio");
                        endPf.logradouro = Console.ReadLine();

                        Console.WriteLine("Este endereço é comercial? S/N");
                        string enderecoComercial = Console.ReadLine().ToUpper();

                        if (enderecoComercial == "S")
                        {
                            endPf.enderecoComercial = true;
                        }
                        else
                        {
                            endPf.enderecoComercial = false;
                        }



                        PessoaFisica novaPf = new PessoaFisica();

                        Console.WriteLine("Digite seu CPF (SOMENTE NÚMEROS");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine("Digite seu NOME ");
                        novaPf.nome = Console.ReadLine();

                        Console.WriteLine("Digite sua DATA DE NASCIMENTO");
                        novaPf.dataDeNascimento = DateTime.Parse(Console.ReadLine());



                        novaPf.nome = "Franklin Souza Lima";
                       
                        novaPf.rendimento = 1500;




                        PessoaFisica pf = new PessoaFisica();
                        //NovaPf.ValidarDataNascimento(NovaPf.dataDeNascimento);

                        Console.WriteLine(pf.PagarImposto(novaPf.rendimento).ToString("N2"));

                        bool idadeValida = novaPf.ValidarDataNascimento(novaPf.dataDeNascimento);


                        Console.WriteLine("Maior de idade: " + idadeValida);

                        if (idadeValida == true)
                        {

                           Console.WriteLine("Cadastro Aprovado");
                           ListaPF.Add(novaPf);
                           Console.WriteLine(pf.PagarImposto(novaPf.rendimento));


                        }
                        else
                        {

                            Console.WriteLine("Cadastro inválido");
                        }


                        break;

                        case "2":
                        foreach (var cadaItem in ListaPF)
                        {
                            Console.WriteLine($"{cadaItem.nome},{cadaItem.cpf},{cadaItem.endereco.logradouro},{cadaItem.dataDeNascimento}");

                        }
                        break; 

                        case "3":

                        Console.WriteLine($"Digite o CPD que deseja remover");
                        string cpfProcurado = Console.ReadLine();

                       PessoaFisica pessoaEncontrada = ListaPF.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                       if (pessoaEncontrada != null)
                       {
                           ListaPF.Remove(pessoaEncontrada);
                           Console.WriteLine($"Cadastro Removido");
                       }else
                       {
                           Console.WriteLine($"CPF Não encontrado");
                       }
                       break;



                    case "4":


                        PessoaJuridica pj = new PessoaJuridica();


                        PessoaJuridica novapj = new PessoaJuridica();

                        Endereco endPj = new Endereco();

                        endPj.logradouro = "Rua Senhor do Socorro";
                        endPj.numero = 32;
                        endPj.complemento = "Próximo a Rotunda";
                        endPj.enderecoComercial = true;


                        novapj.endereco = endPj;
                        novapj.cnpj = "12345678910001";
                        novapj.razaoSocial = "Pessoa Juririca";
                        novapj.rendimento = 8000;

                        Console.WriteLine(pj.PagarImposto(pj.rendimento).ToString("N2"));

                        if (pj.ValidarCNPJ(novapj.cnpj))
                        {

                            Console.WriteLine("Cnpj Válido");
                        }
                        else
                        {

                            Console.WriteLine("Cnpj inválido");


                        }
                        break;


                    case "0":

                        BarraCarregamento("Finalizando");

                        break;

                    default:

                        Console.WriteLine($"Opção inválida, digite uma opção válida");

                        break;

                }



            } while (respostaDoUsuário != "0");

        }
        static void BarraCarregamento(string textoCarregamento)

        {

            Console.ResetColor();
            Console.WriteLine(textoCarregamento);
            Thread.Sleep(500);


            for (var contador = 0; contador < 20; contador++)
            {

                Console.Write($".");
                Thread.Sleep(500);

            }


            Console.ResetColor();

        }



    }



}
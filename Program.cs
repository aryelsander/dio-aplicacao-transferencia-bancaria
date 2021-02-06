using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
         static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
           
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                    
                        ListarContas();
                    break;
                    case "2":
                    
                        InserirConta();
                        break;
                    case "3":
                
                        Transferir();
                    break; 
                    case "4":
                  
                        Sacar();
                    break; 
                    case "5":
                        
                        Depositar();
                    break; 
                    case "C":
                    Console.Title = "DIO Bank - Menu";
                        Console.Clear();
                    break; 
                    case "X":
                        Console.Title = "DIO Bank - Obrigado por utilizar!";
                    break; 

                    default:
                    Console.WriteLine("Opção indisponivel, tente novamente");
                    break;

                    
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void Depositar()
        {
            Console.Title = "DIO Bank - Depósito";
            
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Title = "DIO Bank - Saque";
            Console.Write("Digite o número ad conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.Title = "DIO Bank - Adicionar Nova Conta";
            Console.WriteLine("Inserir nova conta");
            Console.Write("Ditie 1 para Conta Física ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipoConta,entradaSaldo,entradaCredito,entradaNome);
            listaContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.Title = "DIO Bank - Transferência";
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia,listaContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.Title = "DIO Bank - Lista de Contas";
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Title = "DIO Bank - Menu";
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Conta_Bancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string extrato = "extrato.txt";
            int op;
            double saque, deposito, saldo = 0;
            Console.WriteLine("Simulador de Conta Bancaria em C#");

            try
            {
                using (StreamWriter salva = new StreamWriter(extrato,true))
                {
                    do
                    {
                        Console.WriteLine();

                        Console.WriteLine("Digite qual operaçao deseja Realizar? ");
                        Console.WriteLine("1 - Saque \n2 - Deposito \n3 - Saldo \n4 - Extrato \n5 - Encerrar");
                        op = int.Parse(Console.ReadLine());
                        if (op >= 6 || op <= 0)
                        {
                            Console.WriteLine("Operaçao invalida, Digite uma das operaçoes a seguir.\n");
                        }
                        switch (op)
                        {
                            case 1:
                                Console.Write("Digite o Valor a ser sacado: R$");
                                saque = double.Parse(Console.ReadLine());
                                if (saque < saldo)
                                {
                                    Console.WriteLine($"Saque de R${saque} Realizado com Sucesso.");
                                    saldo = saldo - saque;
                                        salva.WriteLine($"Saque de R${saque} Realizado com Sucesso.");
                                         
                                }
                                else
                                {
                                    Console.WriteLine("saldo Indisponivel.");
                                }
                                break;
                            case 2:
                                Console.Write("Digite o Valor a ser Depositado: R$");
                                deposito = double.Parse(Console.ReadLine());
                                if (deposito <= 0)
                                {
                                    Console.WriteLine("Deposite um valor valido.");
                                }
                                else
                                {
                                    Console.WriteLine($"Deposito de R${deposito} realizado com sucesso.");
                                    saldo = saldo + deposito;
                                        salva.WriteLine($"Deposito de R${deposito} realizado com sucesso.");
                                        
                                }
                            break;
                            case 3:
                                Console.Write($"O seu saldo atual é: R${saldo}");
                            break;
                            case 4:
                                salva.Close();
                                Console.WriteLine("Carregando Extrato, Aguarde");

                                using(StreamReader Ler=new StreamReader(extrato))
                                {
                                    string linha;
                                    while((linha = Ler.ReadLine()) != null)
                                    {
                                        Console.WriteLine(linha);
                                    }
                                    
                                }
                            break;
                            case 5:
                                Console.WriteLine("Encerrando Programa");
                            break;
                        }
                    }
                    while (op != 5);
                    {
                        Console.WriteLine("Operaçao invalida, Digite uma das operaçoes a seguir:");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

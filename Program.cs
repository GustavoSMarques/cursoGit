﻿using System;
using System.Globalization;

namespace ex1Curso
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta;

            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                double depositoInicial;
                do
                {
                    Console.Write("Entre o valor de depósito inicial: ");
                    depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (depositoInicial < 0)
                    {
                        Console.WriteLine("")
                    }
                } while (depositoInicial < 0);
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else
            {
                conta = new ContaBancaria(numero, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            conta.Deposito(quantia);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(conta);

            Console.WriteLine();
            do
            {
                Console.WriteLine("Entre um valor para saque: ");
                quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (quantia > conta.Saldo)
                {
                    Console.WriteLine("Valor de saque ultrapassa saldo de conta, digite outro valor e tente novamente.");
                }
            } while (quantia > conta.Saldo);
            conta.Saque(quantia);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(conta);
        }
    }
}

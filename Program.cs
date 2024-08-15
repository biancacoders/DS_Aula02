using System;
using System.Globalization;

namespace inss
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Detalhar Data");
                Console.WriteLine("2 - Calcular Desconto INSS");
                Console.WriteLine("0 - Sair");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        DetalharData();
                        break;
                    case "2":
                        CalcularDescontoINSS();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void DetalharData()
        {
            Console.Write("Digite uma data (dd/MM/yyyy): ");
            DateTime data;
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
            {
                string diaSemana = data.ToString("dddd", new CultureInfo("pt-BR"));
                string mes = data.ToString("MMMM", new CultureInfo("pt-BR"));
                Console.WriteLine($"Dia da semana: {diaSemana}");
                Console.WriteLine($"Mês: {mes}");

                if (diaSemana.Equals("domingo", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Hora atual: {DateTime.Now:HH:mm}");
                }
            }
            else
            {
                Console.WriteLine("Data inválida.");
            }
        }

        static void CalcularDescontoINSS()
        {
            Console.Write("Digite o valor do salário: ");
            decimal salario;
            if (decimal.TryParse(Console.ReadLine(), out salario))
            {
                decimal inss = 0;
                if (salario <= 1302.00m)
                {
                    inss = salario * 0.075m;
                }
                else if (salario <= 2571.29m)
                {
                    inss = salario * 0.09m - 19.53m;
                }
                else if (salario <= 3856.94m)
                {
                    inss = salario * 0.12m - 96.67m;
                }
                else
                {
                    inss = salario * 0.14m - 174.35m;
                }

                decimal salarioLiquido = salario - inss;
                Console.WriteLine($"Valor do INSS: {inss:C}");
                Console.WriteLine($"Salário com desconto do INSS: {salarioLiquido:C}");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }
    }
}
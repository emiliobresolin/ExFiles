using FileEx.Entities;
using System;
using System.Globalization;
using System.IO;

namespace FileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"D:\DEV\CERTIFICADOS\UDEMY\PROJETOS UDEMY\ExecicioArquivos\summary.csv";
            string myFolder = @"D:\DEV\CERTIFICADOS\UDEMY\PROJETOS UDEMY\ExecicioArquivos\vendidos.csv";
            try
            {
                string[] readFolder = File.ReadAllLines(sourcePath);
                using (StreamWriter sw = File.AppendText(myFolder))
                {
                    foreach (string line in readFolder)
                    {
                        string[] space = line.Split(',');
                        string name = space[0];
                        double price = double.Parse(space[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(space[2]);
                        Product product = new Product(name, price, quantity);
                        sw.WriteLine(product.Name + "," + product.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERRO!");
                Console.WriteLine(e.Message);
            }
        }
    }
}

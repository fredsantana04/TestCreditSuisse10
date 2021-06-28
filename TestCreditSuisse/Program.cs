using System;
using TestCreditSuisse.Negocio;

namespace TestCreditSuisse
{
    partial class Program
    {


        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("###########################       CREDITSUISSE - TRADE      ###########################");

                ObterClassificacao();

                Console.ReadKey();
                System.Environment.Exit(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }



        }


        private static void ObterClassificacao()
        {
            var dados = new Trade();
            do
            {
                Console.WriteLine("Reference date (MM/dd/yyyy): ");
                dados.ReferenceDate = Console.ReadLine().ValidarDate();
            } while (dados.ReferenceDate == DateTime.MinValue);


            do
            {
                Console.WriteLine("Number of trade: ");
                dados.NumberTrade = Console.ReadLine().ToIntOrZero();

            } while (dados.NumberTrade == 0);

            while (true)
            {

                do
                {
                    Console.WriteLine("Amount | Type Client (Public or Private) | Date Payment (MM/dd/yyyy)");
                    var alldata = Console.ReadLine();

                    var array = alldata.SplitWithoutEmpty(" ");

                    if (array.Count == 3)
                    {
                        dados.Value = array[0].ToIntOrZero();
                        dados.ClientSector = array[1];
                        dados.NextPaymentDate = array[2].ValidarDate();
                    }


                } while (
                    dados.Value == 0 ||
                    !dados.ClientSector.ToLower().IsIn(ConstantesSetor.Privado, ConstantesSetor.Public) ||
                    dados.NextPaymentDate == DateTime.MinValue
                    );


                Console.WriteLine(dados.ObterClassificacao());

            }
            


        }



    }
}

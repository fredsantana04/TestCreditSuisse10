using System;

namespace TestCreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            



            Console.WriteLine("Date Reference: ");
            DateTime userDateTime;
            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {

                Console.WriteLine("Number of trade: ");
                int intnumberTrade = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Trade Amount: ");
                double tradeAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Type Client: ");
                string strclientes = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Date Payment: ");
                DateTime userDatePagamento;

                if (DateTime.TryParse(Console.ReadLine(), out userDatePagamento))
                {


                    string output = "";

                    int totalDias = (userDatePagamento - userDateTime).Days;

                    if (totalDias > 30)
                    {
                        output = "EXPIRED";
                        Console.WriteLine(output);
                    }

                    if(tradeAmount > 10000 && strclientes == "Private")
                    {
                        output = "HIGHRISK";
                        Console.WriteLine(output);
                    }

                    if (tradeAmount > 10000 && strclientes == "Public")
                    {
                        output = "MEDIUMRISK";
                        Console.WriteLine(output);
                    }


                    //ITrade trade = new ITrade();


                    //var output = OutputInformation(trade);

                    //Console.WriteLine("The date is: " + userDateTime.ToString("dd/MM/yyyy"));
                    //Console.WriteLine("Number of trade is: " + intnumberTrade.ToString());
                    //Console.WriteLine("Trade Amount: " + tradeAmount.ToString() + " " + "Clientes: " + strclientes + "Date Payment: " + userDateTime.ToString("dd/MM/yyyy"));

                }




            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }

            Console.ReadKey();
            System.Environment.Exit(0);

        }

        public string OutputInformation(ITrade trade)
        {

            string output = "";


            int totalDias = (trade.NextPaymentDate - trade.ReferenceDate).Days;

            if (totalDias > 30)
            {
                return output = "EXPIRED";
            }





            return output;
        
        }


        public interface ITrade
        {
 
            double Value { get; } //indicates the transaction amount in dollars
            string ClientSector { get; } //indicates the client´s sector which can be "Public" or "Private"
            DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected

            DateTime ReferenceDate { get; } //indicates when the next payment from the client to the bank is expected

        }

    }
}

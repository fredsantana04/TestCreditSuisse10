using System;
using System.Collections.Generic;
using System.Text;

namespace TestCreditSuisse.Negocio
{
    public interface ITrade
    {

        double Value { get; } //indicates the transaction amount in dollars
        string ClientSector { get; } //indicates the client´s sector which can be "Public" or "Private"
        DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected

        DateTime ReferenceDate { get; } //indicates when the next payment from the client to the bank is expected


    }



    public class Trade : ITrade
    {

        public int NumberTrade { get; set; }
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public DateTime ReferenceDate { get; set; }

        public String Classificacao { get; private set; }

        public string ObterClassificacao()
        {
            var classificacao = "Nenhuma classificação";

            var totalDias = (this.NextPaymentDate - this.ReferenceDate).Days;
            if (totalDias > Convert.ToInt32(ConstantesGeral.totalDiasExpired))
            {
                classificacao = ConstantesClassificacao.Expired;
            }
            else if (this.Value > Convert.ToDouble(ConstantesGeral.valuePagamento) && this.ClientSector == ConstantesSetor.Privado)
            {
                classificacao = ConstantesClassificacao.HighRisk;
            }

            else if (this.Value > Convert.ToDouble(ConstantesGeral.valuePagamento) && this.ClientSector == ConstantesSetor.Public)
            {
                classificacao = ConstantesClassificacao.MediumRisk;
            }

            Classificacao = classificacao;
            return classificacao;

        }
    }


    public abstract class TradeAbs : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public DateTime ReferenceDate { get; set; }

        public abstract TradeAbs Validar();
    }

    
}

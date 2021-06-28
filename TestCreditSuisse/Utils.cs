using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestCreditSuisse
{
    public static class Utils
    {
        public static Int32 ToIntOrZero<T>(this T item) where T : IConvertible
        {
            if (item == null)
            {
                return 0;
            }

            try
            {
                return Convert.ToInt32(item);
            }
            catch (Exception)
            {
            }

            return 0;
        }

        public static DateTime ValidarDate(this String datetime)
        {
            try
            {
                return DateTime.Parse(datetime, new System.Globalization.CultureInfo("en-US", true));
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        public static Boolean IsIn<T>(this T item, params T[] itens)
        {
            if (itens == null || itens.Length == 0) { return false; }
            return IsIn(item, itens.AsEnumerable());
        }

        public static Boolean IsIn<T>(this T item, IEnumerable<T> itens)
        {
            return itens.ToList().Contains(item);
        }


        public static List<String> SplitWithoutEmpty(this String valores, String separadorMultiplo)
        {
            var r = new Regex(separadorMultiplo);
            var retorno = r.Split(valores.ToEmptyIfNull()).ToList();
            retorno.RemoveAll(x => x.IsNullOrEmpty());

            return retorno;
        }

        public static Boolean IsNullOrEmpty(this String valor)
        {
            return String.IsNullOrEmpty(valor);
        }

        public static String ToEmptyIfNull(this String item)
        {
            return item ?? String.Empty;
        }




    }
}

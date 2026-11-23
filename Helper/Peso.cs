using System;
using System.Globalization;

namespace PMS_v1   // keep as PMS_v1 so every page can see it
{
    /// <summary>
    /// The one place that writes peso amounts, so every screen shows them the same way.
    ///   Peso.Format(1234.5m)  ->  "₱ 1,234.50"
    ///   Peso.Whole(1234.5m)   ->  "₱ 1,234"      (whole pesos, for the stat cards)
    /// The overloads that take an object accept a value straight from a database reader.
    /// Always invariant culture, so the text is the same on every PC.
    /// </summary>
    public static class Peso
    {
        public const string Symbol = "₱";

        public static string Format(decimal value) =>
            Symbol + " " + value.ToString("N2", CultureInfo.InvariantCulture);

        public static string Format(object value) => Format(Convert.ToDecimal(value));

        public static string Whole(decimal value) =>
            Symbol + " " + value.ToString("N0", CultureInfo.InvariantCulture);

        public static string Whole(object value) => Whole(Convert.ToDecimal(value));
    }
}
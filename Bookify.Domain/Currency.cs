namespace Bookify.Domain
{
    public record Currency
    {
        internal static Currency None = new Currency("");
        public static Currency Usd = new Currency("USD");
        public static Currency Eur = new Currency("EUR");
        private Currency(string code)
        {
            Code = code;
        }
        public string Code { get; init; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) 
                   ?? throw new ApplicationException($"Currency with code {code} does not exist");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            Usd, Eur
        };
    }
}

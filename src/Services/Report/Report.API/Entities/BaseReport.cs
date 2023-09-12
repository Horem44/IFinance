namespace Report.API.Entities
{
    public abstract class BaseReport
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }
    }
}

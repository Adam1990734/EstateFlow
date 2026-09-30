namespace EstateFlow.Server.Domain
{
    public class UtilityType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Provider> Providers { get; set; } = new List<Provider>();
    }
}

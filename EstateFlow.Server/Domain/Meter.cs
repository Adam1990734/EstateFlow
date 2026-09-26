using Microsoft.EntityFrameworkCore;
namespace EstateFlow.Server.Domain;
public class Meter
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string SerialNumber { get; set; }
    public Guid PropertyId { get; set; }
    public Property? Property { get; set; }
}
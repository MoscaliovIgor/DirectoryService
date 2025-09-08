namespace DirectoryService.Domain.Location;

public class Location
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Adress { get; private set; }

    public string TimeZone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
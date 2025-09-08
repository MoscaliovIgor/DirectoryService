using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Department;

public class Department
{
    public Department( string name, string identifier, short depth, DateTime createdAt, DateTime updatedAt)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 150)
        {
            throw new ArgumentException("Invalid Name");
        }

        Name = name;

        if ((string.IsNullOrWhiteSpace(identifier)
            || name.Length < 3
            || name.Length > 150)
            && Regex.IsMatch(identifier, @"^[a-zA-Z0-9]+$"))
        {
            throw new ArgumentException("Invalid Identifier");
        }

        Identifier = identifier;

        CreatedAt = DateTime.UtcNow;

        if (UpdatedAt < CreatedAt)
        {
            throw new InvalidOperationException("UpdatedAt не может быть раньше CreatedAt");
        }

        UpdatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid? ParentId { get; private set; }

    // public Department? Parent { get; private set; }
    //
    // public List<Department> Children { get; private set; }
    public string Name { get; private set; }

    public string Identifier { get; private set; }

    public string Path { get; private set; } // денормализованный путь к подразделению (hq.it.dev-team) ...

    public short Depth { get; private set; } // глубина подразделения

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
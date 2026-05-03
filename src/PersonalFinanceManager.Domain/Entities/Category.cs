namespace PersonalFinanceManager.Domain.Entities;

public class Category
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string? ParentCategoryName { get; private set; }

    public Category(string name, string? parentCategoryName = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.");

        Id = Guid.NewGuid();
        Name = name;
        ParentCategoryName = parentCategoryName;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Category name cannot be empty.");

        Name = newName;
    }

    public override string ToString() => Name;
}
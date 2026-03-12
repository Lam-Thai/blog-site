namespace BlogSite;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Models.Post> Posts { get; set; } = new();
}
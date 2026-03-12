namespace BlogSite;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Models.Post> Posts { get; set; }
}
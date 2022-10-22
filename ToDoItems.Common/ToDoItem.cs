namespace ToDoItems.Common;
public class ToDoItem
{
    public Guid id { get; set; } = Guid.NewGuid();

    public string ItemType { get; set; } = "Shopping";

    public string Name { get; set; }
    public string Description { get; set; }

    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(1);

    public override string ToString()
    {
        return $"Id: {id}, PartKey: {ItemType}, Name: {Name}";
    }
}

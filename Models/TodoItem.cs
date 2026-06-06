namespace keepsake.Models;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Tittle { get; set; } = string.Empty;
    public Boolean IsCompleated { get; set; } = false;
    public DateTime CreateAt { get; set; }

}

namespace keepsake.Domain.Entities;


public class TodoItem
{
    public Guid Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreateAt { get; init; }
    public bool IsCompleated { get; set; }
    public DateTime? CompletedAt { get; private set; }


    private TodoItem() { }


    public TodoItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("the title is empty");
        }
        Id = Guid.NewGuid();
        Title = title.Trim();
        IsCompleated = false;
        CreateAt = DateTime.UtcNow;
    }
    public void Finish()
    {
        IsCompleated = true;
        return;
    }

    public void UnFinished()
    {
        IsCompleated = false;
        return;
    }

    public void ChangeTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("the title is empty");
        }
        Title = title.Trim();
        return;
    }
}

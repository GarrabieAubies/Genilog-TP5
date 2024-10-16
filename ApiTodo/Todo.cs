public class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }

    public DateTime Deadline { get; set; }

    public Todo(string title, bool isComplete, DateTime deadline)
    {
        Title = title;
        IsComplete = isComplete;
        Deadline = deadline;
    }


}
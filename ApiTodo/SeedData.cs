public static class SeedData
{
    public static void InitData(TodoContext context)
    {
        Todo todo1 = new Todo("Learn C#", false, DateTime.Now.AddDays(7));
        Todo todo2 = new Todo("Learn ASP.NET Core", false, DateTime.Now.AddDays(14));
        Todo todo3 = new Todo("Learn EF Core", false, DateTime.Now.AddDays(21));

        context.Todos.Add(todo1);
        context.Todos.Add(todo2);
        context.Todos.Add(todo3);
        context.SaveChanges();
    }
}
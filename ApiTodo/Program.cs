namespace ApiTodo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SeedData.InitData(); // Call the static method using the class name

            var builder = WebApplication.CreateBuilder(args);
            // Removed incomplete line causing errors
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization(); // Register authorization services
            builder.Services.AddControllers(); // Register controller services

            builder.Services.AddDbContext<TodoContext>();
            builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });


            builder.Services.AddControllers();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
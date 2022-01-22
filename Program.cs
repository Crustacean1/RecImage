using Microsoft.EntityFrameworkCore;
public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        string connectionString = builder.Configuration.GetConnectionString("cs");
        builder.Services.AddDbContext<RecImage.Repositories.RepositoryContext>((options)=>{options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));});
        builder.Services.AddScoped<RecImage.Repositories.RepositoryManager>();
        builder.Services.AddSingleton<RecImage.Repositories.ImageRepository>();
        builder.Services.AddScoped<RecImage.Services.ImageService>();

        builder.Services.AddHostedService<RecImage.Logic.ImageProcessorService>();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
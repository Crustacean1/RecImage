using Microsoft.EntityFrameworkCore;
public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddCors();

        builder.Services.AddControllers();

        string connectionString = builder.Configuration.GetConnectionString("cs");
        builder.Services.AddDbContext<RecImage.Repositories.RepositoryContext>((options)=>{options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));});

        builder.Services.AddScoped<RecImage.Repositories.RepositoryManager>();
        builder.Services.AddScoped<RecImage.Repositories.ImageRepository>();

        builder.Services.AddScoped<RecImage.Services.ProcessorService>();
        builder.Services.AddScoped<RecImage.Services.AuthorizationService>();

        //builder.Services.AddHostedService<RecImage.Logic.ImageProcessorService>();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        RecImage.Logic.FilterFactory.AddFilter<RecImage.Logic.BlurFilter>("Blur");
        RecImage.Logic.FilterFactory.AddFilter<RecImage.Logic.FlipFilter>("Flip");
        RecImage.Logic.FilterFactory.AddFilter<RecImage.Logic.InverseFilter>("Inverse");
        RecImage.Logic.FilterFactory.AddFilter<RecImage.Logic.WobbleFilter>("BoogieWoogie");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(options =>{options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();});

        app.MapControllers();

        app.Run();
    }
}
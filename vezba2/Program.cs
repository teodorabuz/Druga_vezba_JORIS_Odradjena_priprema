
using vezba2.Interfaces;
using vezba2.Repositories;

namespace vezba2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<IHotelRepository, InMemoryHotelRepository>();
            builder.Services.AddTransient<IHotelRepository, SqlHotelRepository>();
            //builder.Services.AddSingleton<ISobaRepository, InMemorySobaRepository>();
            builder.Services.AddTransient<ISobaRepository, SqlSobaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

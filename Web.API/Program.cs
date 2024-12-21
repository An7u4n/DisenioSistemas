using Data;
using Data.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.UserService;
using Services.AulaService;
using Services.ReservaService;
using Services.AuthService;
using Services.ReservaService.Interfaces;

namespace Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Configura CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin() // Permitir todos los orígenes
                           .AllowAnyMethod() // Permitir todos los métodos HTTP
                           .AllowAnyHeader(); // Permitir todos los encabezados
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("bddsqlite"), b => b.MigrationsAssembly("Web.API"));
            });

            // Registering UserService and AulaService
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAulaService, AulaService>();
            builder.Services.AddScoped<IReservaService, ReservaService>();
            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<ReservaDAO>();
            builder.Services.AddScoped<UserDAO>();
            builder.Services.AddScoped<AulaDAO>();
            builder.Services.AddScoped<AnioLectivoDAO>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Habilita CORS
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

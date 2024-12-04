using Data;
using Data.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Services.UserService;
using System.Text.Json.Serialization.Metadata;

namespace Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura los servicios
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Configura CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()    // Permitir todos los orígenes
                           .AllowAnyMethod()    // Permitir todos los métodos HTTP
                           .AllowAnyHeader();   // Permitir todos los encabezados
                });
            });

            // Configura los controladores y opciones de JSON
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IncludeFields = true;
                    options.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver
                    {
                        Modifiers =
                        {
                            jsonTypeInfo =>
                            {
                                if (jsonTypeInfo.Type == typeof(AulaDTO))
                                {
                                    jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                                    {
                                        TypeDiscriminatorPropertyName = "TipoAula",
                                        IgnoreUnrecognizedTypeDiscriminators = false,
                                        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                                        DerivedTypes =
                                        {
                                            new JsonDerivedType(typeof(AulaInformaticaDTO), "Informatica"),
                                            new JsonDerivedType(typeof(AulaMultimediosDTO), "Multimedios"),
                                            new JsonDerivedType(typeof(AulaSinRecursosAdicionalesDTO), "SinRecursosAdicionales")
                                        }
                                    };
                                }
                            }
                        }
                    };
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configura la base de datos
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("bddsqlite"), b => b.MigrationsAssembly("Web.API"));
            });

            // Configura los servicios y DAOs
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<UserDAO>();
            builder.Services.AddScoped<AnioLectivoDAO>();

            var app = builder.Build();

            // Aplica las migraciones pendientes
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }

            // Configura el pipeline de solicitudes HTTP
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

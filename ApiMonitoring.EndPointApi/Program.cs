using ApiMonitoring.Application.Services.ServerService;
using ApiMonitoring.Application.Services.UserService;
using ApiMonitoring.Application.Services.UserServices;
using ApiMonitoring.Persistance.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ApiMonitoring.Persistance.Repositories;
using ApiMonitoring.Domain.Entities;
using ApiMonitoring.Application.Mapper;

namespace ApiMonitoring.EndPointApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            // Add services to the container.
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IGenericRepository<Server>, ServerRepository>();

            builder.Services.AddScoped<IServerServices, ApiMonitoring.Application.Services.ServerService.ServerService>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

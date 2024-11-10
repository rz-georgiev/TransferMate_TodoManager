using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using TM_TodoManager.Application;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Application.Interfaces;
using TM_TodoManager.Infrastructure;
using TM_TodoManager.Shared.Models;

namespace TransferMate_TodoManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var connectionString = builder.Configuration.GetConnectionString("TransferMate");
            Debug.WriteLine($"Asdas -> {connectionString}");
            Console.WriteLine($"Asdas2 -> {connectionString}");
            try
            {
                var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
                Console.WriteLine($"Asdas3 -> {serverVersion.ToString()}");
                builder.Services.AddDbContext<TransferMateDbContext>(
              dbContextOptions => dbContextOptions
                  .UseMySql(connectionString, serverVersion)
                  .LogTo(Console.WriteLine, LogLevel.Information)
                  .EnableSensitiveDataLogging()
                  .EnableDetailedErrors());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            builder.Services.AddTransient<IUserTaskService, UserTaskService>();
            builder.Services.AddTransient<IStatusService, StatusService>();

            var app = builder.Build();

            using (var Scope = app.Services.CreateScope())
            {
                var context = Scope.ServiceProvider.GetRequiredService<TransferMateDbContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) { }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapPost("/createTask", async (NewTaskDto dto, IUserTaskService service) =>
            {
                var result = await service.CreateTaskAsync(dto);
                return result.IsOk ? Results.Ok(result) : Results.BadRequest(result);
            });

            app.MapPost("/updateTask", async (UpdateTaskDto dto, IUserTaskService service) =>
            {
                var result = await service.UpdateTaskAsync(dto);
                return result.IsOk ? Results.Ok(result) : Results.BadRequest(result);
            });

            app.MapGet("/getPendingTasks", async (IUserTaskService service) =>
            {
                var result = await service.GetPendingTasksAsync();
                return result.IsOk ? Results.Ok(result) : Results.BadRequest(result);
            });

            app.MapGet("/getOverdueTasks", async (IUserTaskService service) =>
            {
                var result = await service.GetOverdueTasksAsync();
                return result.IsOk ? Results.Ok(result) : Results.BadRequest(result);
            });

            app.MapGet("/statuses", async (IStatusService service) =>
            {
                var result = await service.GetAll();
                return result.IsOk ? Results.Ok(result) : Results.BadRequest(result);
            });

            app.Run();
        }
    }
}
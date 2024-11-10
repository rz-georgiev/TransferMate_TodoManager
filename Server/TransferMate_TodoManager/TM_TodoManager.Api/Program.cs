using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using TM_TodoManager.Application;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Application.Interfaces;
using TM_TodoManager.Infrastructure;
using TM_TodoManager.Shared.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TransferMate_TodoManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(80);
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Setting up AutoMapper profile
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            ///Configuring database connection
            var connectionString = builder.Configuration.GetConnectionString("TransferMate");

            if (builder.Configuration["DBHOST"] != null)
            {
                var host = builder.Configuration["DBHOST"];
                var port = builder.Configuration["DBPORT"];
                var password = builder.Configuration["MYSQL_PASSWORD"];
                var userid = builder.Configuration["MYSQL_USER"];
                var database = builder.Configuration["MYSQL_DATABASE"];

                connectionString = $"Server={host};Port={port};Database={database};User={userid};Password={password}";
            }

            Console.WriteLine(connectionString);
            try
            {
                var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowAllHeadersPolicy",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            var app = builder.Build();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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

            MapEndpoints(app);

            app.Run();
        }

        public static void MapEndpoints( WebApplication app)
        {
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

        }
    }
}
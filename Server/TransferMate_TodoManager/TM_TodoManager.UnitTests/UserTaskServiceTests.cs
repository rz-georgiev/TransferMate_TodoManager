using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Xml;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Application.Interfaces;
using TM_TodoManager.Core.Entities;
using TM_TodoManager.Infrastructure;

namespace TransferMate_TodoManager.UnitTests
{
    public class UserTaskServiceTests
    {
        private DbContextOptions<TransferMateDbContext> _options;
        private IMapper _mapper;
        private UserTaskService _service;

        public UserTaskServiceTests()
        {
            // Setup In-memory database for testing
            _options = new DbContextOptionsBuilder<TransferMateDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserTask, NewTaskDto>();
                cfg.CreateMap<NewTaskDto, UserTask>();
                cfg.CreateMap<UserTask, UpdateTaskDto>();
                cfg.CreateMap<UpdateTaskDto, UserTask>();
                cfg.CreateMap<UserTask, ReadTaskDto>();
                cfg.CreateMap<ReadTaskDto, UserTask>();
            });
            _mapper = config.CreateMapper();

            // Initialize service with in-memory db context and AutoMapper
            using (var context = new TransferMateDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            _service = new UserTaskService(new TransferMateDbContext(_options), _mapper);
        }

        [Fact]
        public async void GetPendingTasksAsync_ReturnsThreeFour_WithProvidedWithDefaultData()
        {
            using var context = new TransferMateDbContext(_options);
            _service = new UserTaskService(context, _mapper);

            var result = await _service.GetPendingTasksAsync();
            Assert.True(result.Result.Count() == 3);
        }

        [Fact]
        public async void GetOverdueTasksAsync_ReturnsTwoRecords_WithProvidedWithDefaultData()
        {
            using var context = new TransferMateDbContext(_options);
            _service = new UserTaskService(context, _mapper);

            var result = await _service.GetOverdueTasksAsync();
            Assert.True(result.Result.Count() == 2);
        }

        [Fact]
        public async void CreateTaskAsync_ReturnsTrue_WhenValidNameIsProvided()
        {
            using var context = new TransferMateDbContext(_options);
            _service = new UserTaskService(context, _mapper);

            var validTask = new NewTaskDto { Name = "1234", DueDate = DateTime.UtcNow, };
            var result = await _service.CreateTaskAsync(validTask);

            Assert.True(result.IsOk);
        }

        [Fact]
        public async void CreateTaskAsync_ReturnsFalse_WhenInvalidNameIsProvided()
        {
            using var context = new TransferMateDbContext(_options);
            _service = new UserTaskService(context, _mapper);

            var invalidTaskFirst = new NewTaskDto { Name = "", DueDate = null, };
            var invalidTaskSecond = new NewTaskDto { Name = "123456789012345678901234567890123456789012345678901", DueDate = DateTime.UtcNow, };

            var firstResult = await _service.CreateTaskAsync(invalidTaskFirst);
            var secondResult = await _service.CreateTaskAsync(invalidTaskSecond);

            Assert.False(firstResult.IsOk && secondResult.IsOk);
        }

        [Theory]
        [InlineData(1, 2, "123", "2024-11-08T10:00:00")]
        public async void UpdateTaskAsync_ReturnsTrue_WhenValidParametersArePassed(int id, int statusId, string name, string dueDateString)
        {
            var dueDate = DateTime.Parse(dueDateString);

            using var context = new TransferMateDbContext(_options);
            _service = new UserTaskService(context, _mapper);

            var updateTask = new UpdateTaskDto { Id = id, StatusId = statusId, Name = name, DueDate = dueDate };
            var result = await _service.UpdateTaskAsync(updateTask);

            Assert.True(result.IsOk);
        }

        [Theory]
        [InlineData(1, 2, "", "2024-11-08T10:00:00")]
        [InlineData(1, 2, "123456789012345678901234567890123456789012345678901", "2024-11-08T10:00:00")]
        [InlineData(0, 2, "123", "2024-11-08T10:00:00")]
        [InlineData(1, 10, "123", "2024-11-08T10:00:00")]
        public async void UpdateTaskAsync_ReturnsFalse_WhenInvalidParameterArePassed(int id, int statusId, string name, string dueDateString)
        {
            var dueDate = DateTime.Parse(dueDateString);

            using var context = new TransferMateDbContext(_options);
            _service = new UserTaskService(context, _mapper);

            var updateTask = new UpdateTaskDto { Id = id, StatusId = statusId, Name = name, DueDate = dueDate };
            var result = await _service.UpdateTaskAsync(updateTask);

            Assert.False(result.IsOk);
        }
    }
}
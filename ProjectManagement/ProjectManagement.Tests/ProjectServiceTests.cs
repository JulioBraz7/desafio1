
using Moq;
using NUnit.Framework;
using ProjectManagement.Application.Services;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Tests {
    public class ProjectServiceTests {
        private Mock<IProjectRepository> _mockRepo;
        private ProjectService _service;

        [SetUp]
        public void Setup() {
            _mockRepo = new Mock<IProjectRepository>();
            _service = new ProjectService(_mockRepo.Object);
        }

        [Test]
        public async Task AddProject_ShouldCallRepository() {
            var project = new Project { Id = 1, Name = "Test Project", Description = "Test Desc", Deadline = DateTime.Now };
            await _service.AddProjectAsync(project);
            _mockRepo.Verify(r => r.AddAsync(project), Times.Once);
        }

        [Test]
        public async Task GetAllProjects_ShouldReturnProjects() {
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Project>());
            var result = await _service.GetAllProjectsAsync();
            Assert.IsNotNull(result);
        }
    }
}

public class ProjectServiceTests {
    private readonly ProjectService _service;
    private readonly Mock<IProjectRepository> _mockRepo;

    public ProjectServiceTests() {
        _mockRepo = new Mock<IProjectRepository>();
        _service = new ProjectService(_mockRepo.Object);
    }

    [Fact]
    public async Task Should_Add_New_Project() {
        var project = new ProjectDTO { Name = "New Project", Description = "Test" };
        await _service.AddProjectAsync(project);
        _mockRepo.Verify(r => r.AddAsync(It.IsAny<Project>()), Times.Once);
    }
}

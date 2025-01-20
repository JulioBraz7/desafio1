[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase {
    private readonly ProjectService _projectService;

    public ProjectController(ProjectService projectService) {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }
}

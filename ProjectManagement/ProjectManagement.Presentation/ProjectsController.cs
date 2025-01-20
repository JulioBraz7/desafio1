using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProjectsController : ControllerBase {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService) {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project) {
            await _projectService.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Project project) {
            if (id != project.Id) return BadRequest();
            await _projectService.UpdateProjectAsync(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}

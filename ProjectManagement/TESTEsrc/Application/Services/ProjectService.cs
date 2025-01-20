public class ProjectService {
    private readonly IProjectRepository _projectRepository;
    
    public ProjectService(IProjectRepository projectRepository) {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync() {
        var projects = await _projectRepository.GetAllAsync();
        return projects.Select(p => new ProjectDTO(p.Id, p.Name, p.Description, p.Deadline));
    }
}

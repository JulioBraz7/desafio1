namespace ProjectManagement.Application.Services {
    using ProjectManagement.Domain.Entities;
    using ProjectManagement.Domain.Interfaces;

    public class ProjectService {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository) {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync() {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id) {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task AddProjectAsync(Project project) {
            await _projectRepository.AddAsync(project);
        }

        public async Task UpdateProjectAsync(Project project) {
            await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteProjectAsync(int id) {
            await _projectRepository.DeleteAsync(id);
        }
    }
}
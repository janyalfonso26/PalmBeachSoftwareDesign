using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Dtos.Project;
using DAL.Infrastructure;

namespace BLL.Services
{
    public class ProjectService: IProjectService
    {
        private readonly IProjectRepository repository;

        public ProjectService(IProjectRepository _repository)
        {
            repository = _repository;
        }
        public ProjectDto GetProjecById(int projectId)
        {
            return repository.Get(m => m.Id == projectId).ToProjectDto();
        }

        public List<ProjectDto> GetAllProjects()
        {
            return repository.All().ToList().ToProjectDtos();
        }

        public List<ProjectDto> GetProjectsByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(ProjectDto dto)
        {
            repository.Update(dto.ToProject());
        }
    }
}

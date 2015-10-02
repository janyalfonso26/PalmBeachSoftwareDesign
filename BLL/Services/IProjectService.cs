using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Customer;
using BLL.Dtos.Project;

namespace BLL.Services
{
    public interface IProjectService
    {
        ProjectDto GetProjecById(int projectId);
        List<ProjectDto> GetAllProjects();
        List<ProjectDto> GetProjectsByName(string name);
        void UpdateProject(ProjectDto dto);
    }
}

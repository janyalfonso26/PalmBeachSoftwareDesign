using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Project
{
    public static class ProjectExtensions
    {
        public static ProjectDto ToProjectDto(this DAL.Entities.Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                CustomerId = project.CustomerId
            };
        }

        public static DAL.Entities.Project ToProject(this ProjectDto projectDto)
        {
            return new DAL.Entities.Project
            {
                Id = projectDto.Id,
                Name = projectDto.Name,
                CustomerId = projectDto.CustomerId
            };
        }
        public static List<ProjectDto> ToProjectDtos(this List<DAL.Entities.Project> projects)
        {
            return projects.Select(project => new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                CustomerId = project.CustomerId
            }).ToList();
        }

        public static List<DAL.Entities.Project> ToProjects(this List<ProjectDto> projectDtos)
        {
            return projectDtos.Select(project => new DAL.Entities.Project
            {
                Id = project.Id,
                Name = project.Name,
                CustomerId = project.CustomerId
            }).ToList();
        }

    }
}

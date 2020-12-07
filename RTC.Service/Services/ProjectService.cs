using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RTC.Service.Services
{
    public class ProjectService : IProjectService
    {
        IProjectRepository projectRepository;
        IUnitOfWork unitOfWork;

        public ProjectService(IProjectRepository _projectRepository, IUnitOfWork _unitOfWork)
        {
            this.projectRepository = _projectRepository;
            this.unitOfWork = _unitOfWork;
        }
        public void Add(RTC_Project project)
        {
            projectRepository.Add(project);
        }

        public void Delete(int id)
        {
            projectRepository.Delete(id);
        }

        public void Delete(RTC_Project project)
        {
            projectRepository.Delete(project);
        }

        public IEnumerable<RTC_Project> GetAll()
        {
            return projectRepository.GetAll();

        }

        public IEnumerable<RTC_Project> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                int id = int.Parse(keyword);
                return projectRepository.GetMulti(x => x.ProjectName.Contains(keyword) || x.ProjectID.Equals(id) || x.ProjectCode.Contains(keyword));
            }
            else
                return projectRepository.GetAll();
        }

        public IEnumerable<RTC_Project> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RTC_Project> GetAllWiithInfoPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public RTC_Project GetByProjectID(int id)
        {
            return projectRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_Project project)
        {
            projectRepository.Update(project);
        }
    }
}

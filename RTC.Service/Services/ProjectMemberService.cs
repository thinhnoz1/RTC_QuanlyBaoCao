using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace RTC.Service.Services
{
    public class ProjectMemberService : IProjectMemberService
    {
        IProjectMemberRepository projectMemberRepository;
        IUnitOfWork unitOfWork;

        public ProjectMemberService(IProjectMemberRepository _projectMemberRepository, IUnitOfWork _unitOfWork)
        {
            this.projectMemberRepository = _projectMemberRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(RTC_ProjectMember member)
        {
            projectMemberRepository.Add(member);
        }

        public void Delete(int id)
        {
            projectMemberRepository.Delete(id);
        }

        public void DeleteMulti(int id)
        {
            projectMemberRepository.DeleteMulti(x => x.UserID == id);

        }

        public void DeleteMultiByProjectID(int id)
        {
            projectMemberRepository.DeleteMulti(x => x.ProjectID == id);

        }

        public List<int> GetUserProject(int userid)
        {
            var firstList = projectMemberRepository.GetMulti(x => x.UserID == userid).ToList();
            var secondList = firstList.Select(x => x.ProjectID);
            var result = secondList.Distinct().ToList();
            return result;
        }

        public IEnumerable<RTC_ProjectMember> GetAll(int userID)
        {
            return projectMemberRepository.GetMulti(x => x.UserID == userID);
        }

        public IEnumerable<RTC_ProjectMember> GetAll()
        {
            return projectMemberRepository.GetAll();
        }

        public RTC_ProjectMember GetByID(int id)
        {
            return projectMemberRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_ProjectMember member)
        {
            projectMemberRepository.Update(member);
        }
    }
}

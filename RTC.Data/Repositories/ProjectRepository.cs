using PagedList;
using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.Repositories
{
    public class ProjectRepository : RepositoryBase<RTC_Project>, IProjectRepository
    {
        public ProjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<RTC_Project> GetByProjectID(int id)
        {
            return this.DbContext.RTC_Projects.Where(x => x.ProjectID == id);
        }

        public IEnumerable<RTC_Project> ListAllPaging(int page, int pageSize)
        {
            return this.DbContext.RTC_Projects.OrderByDescending(x => x.DateStarted).ToPagedList(page, pageSize);
        }

        public IEnumerable<RTC_Project> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<RTC_Project> model = this.DbContext.RTC_Projects;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ProjectName.Contains(searchString)).OrderByDescending(x => x.DateStarted);
            }
            return model.OrderByDescending(x => x.DateStarted).ToPagedList(page, pageSize);
        }
    }
}

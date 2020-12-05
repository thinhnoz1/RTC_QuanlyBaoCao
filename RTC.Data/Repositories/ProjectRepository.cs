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
    }
}

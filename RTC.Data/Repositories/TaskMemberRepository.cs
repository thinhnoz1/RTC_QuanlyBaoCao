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
    public class TaskMemberRepository : RepositoryBase<RTC_TaskMember>, ITaskMemberRepository
    {
        public TaskMemberRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}

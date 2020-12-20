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
    public class CommentListRepository : RepositoryBase<RTC_CommentList>, ICommentListRepository
    {
        public CommentListRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }
}

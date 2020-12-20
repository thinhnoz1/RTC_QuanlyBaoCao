using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface ICommentListService
    {
        void Add(RTC_CommentList comment);
        void Delete(long id);
        RTC_CommentList GetByID(long id);
        void SaveChanges();
        IEnumerable<RTC_CommentList> GetAll(long taskID);
        IEnumerable<RTC_CommentList> GetAll();
    }
}

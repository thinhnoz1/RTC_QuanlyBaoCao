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
    public class CommentListService : ICommentListService
    {
        ICommentListRepository commentListRepository;
        IUnitOfWork unitOfWork;

        public CommentListService(ICommentListRepository _commentListRepository, IUnitOfWork _unitOfWork)
        {
            this.commentListRepository = _commentListRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(RTC_CommentList comment)
        {
            commentListRepository.Add(comment);
        }

        public void Delete(long id)
        {
            commentListRepository.Delete(id);
        }

        public IEnumerable<RTC_CommentList> GetAll(long taskID)
        {
            var a = commentListRepository.GetMulti(x => x.TaskID.Equals(taskID));
            return a;
        }

        public IEnumerable<RTC_CommentList> GetAll()
        {
            var a = commentListRepository.GetAll();
            return a;
        }

        public RTC_CommentList GetByID(long id)
        {
            return commentListRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }
    }
}

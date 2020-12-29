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
    public class BackgroundImageService : IBackgroundImageService
    {
        IBackgroundImageRepository backgroundImageRepository;
        IUnitOfWork unitOfWork;

        public BackgroundImageService(IBackgroundImageRepository _backgroundImageRepository, IUnitOfWork _unitOfWork)
        {
            this.backgroundImageRepository = _backgroundImageRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(RTC_BackgroundImage img)
        {
            backgroundImageRepository.Add(img);
        }

        public void Delete(int id)
        {
            backgroundImageRepository.Delete(id);
        }

        public IEnumerable<RTC_BackgroundImage> GetAll()
        {
            return backgroundImageRepository.GetAll();
        }

        public RTC_BackgroundImage GetByID(int id)
        {
            return backgroundImageRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_BackgroundImage img)
        {
            backgroundImageRepository.Update(img);
        }
    }
}

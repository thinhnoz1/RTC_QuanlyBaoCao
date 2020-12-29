using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.IServices
{
    public interface IBackgroundImageService
    {
        void Add(RTC_BackgroundImage task);
        void Update(RTC_BackgroundImage task);
        void Delete(int id);
        RTC_BackgroundImage GetByID(int id);
        void SaveChanges();
        IEnumerable<RTC_BackgroundImage> GetAll();
    }
}

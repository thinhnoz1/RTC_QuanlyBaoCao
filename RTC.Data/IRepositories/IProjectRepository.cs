using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.IRepositories
{
    public interface IProjectRepository
    {
        IEnumerable<RTC_Project> GetByProjectID (int id);
    }
}

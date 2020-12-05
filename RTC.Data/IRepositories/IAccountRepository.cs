using RTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Data.IRepositories
{
    public interface IAccountRepository
    {
        IEnumerable<RTC_Account> GetByEmail(string email);
    }
}

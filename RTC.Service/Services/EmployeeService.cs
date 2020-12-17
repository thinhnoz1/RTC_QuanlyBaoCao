using RTC.Data.Infrastructure;
using RTC.Data.IRepositories;
using RTC.Model.Models;
using RTC.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        IUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeRepository _employeeRepository, IUnitOfWork _unitOfWork)
        {
            this.employeeRepository = _employeeRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(RTC_Employee employee)
        {
            employeeRepository.Add(employee);
        }

        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }



        public IEnumerable<RTC_Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public RTC_Employee GetByID(int id)
        {
            return employeeRepository.GetSingleById(id);
        }

        public IEnumerable<RTC_Employee> ListAllPaging(int page, int pageSize)
        {
            return employeeRepository.ListAllPaging(page, pageSize);
        }

        public IEnumerable<RTC_Employee> ListAllPaging(string searchString, int page, int pageSize)
        {
            return employeeRepository.ListAllPaging(searchString, page, pageSize);
        }

        public IEnumerable<RTC_Employee> GetUsersWithList(List<int> listID)
        {
            var list = employeeRepository.GetUsersWithList(listID);
            return list;
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void Update(RTC_Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}

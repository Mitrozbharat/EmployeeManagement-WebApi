using EmployeeManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
       public   Task<IEnumerable<TblEmployee>> GetAllAsync();
        public Task<TblEmployee?> GetByIdAsync(int id);
        public Task<int> AddAsync(TblEmployee employee);
        public Task<TblEmployee> UpdateAsync(TblEmployee employee);
        public Task<bool> DeleteAsync(int id);
    }
}

using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync();
        public Task<EmployeeDTO?> GetByIdAsync(int id);
        public Task<int> AddAsync(EmployeeCreateDTO employee);
        public Task<EmployeeUpdateDTO?> UpdateAsync(EmployeeUpdateDTO employee);
        public Task<bool> DeleteAsync(int id);
    }
}

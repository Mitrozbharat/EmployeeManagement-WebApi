using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;

        }
        public async Task<int> AddAsync(TblEmployee employee)
        {
            await _context.TblEmployees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.TblEmployees.FirstOrDefaultAsync(emp => emp.Id == id);
            if (employee == null)
            {
                return false; // Employee not found
            }

            _context.TblEmployees.Remove(employee);
            await _context.SaveChangesAsync();

            return true; // Employee successfully deleted
        }



        public async Task<IEnumerable<TblEmployee>> GetAllAsync()
        {
            return await _context.TblEmployees.Include(x=>x.Department).ToListAsync();  
        }

        public async Task<TblEmployee?> GetByIdAsync(int id)
        {
            return await _context.TblEmployees.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<TblEmployee> UpdateAsync(TblEmployee employee)
        {
            _context.TblEmployees.Update(employee);
             await  _context.SaveChangesAsync();
            return employee;
        }
    }
}

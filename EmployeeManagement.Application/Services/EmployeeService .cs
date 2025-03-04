using AutoMapper;
using EmployeeManagement.Application.DataTransferObject;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(EmployeeCreateDTO employee)
        {
            // Map DTO to Domain Entity
            var emp = new TblEmployee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId,
                JobTitle = employee.JobTitle,
                PhoneNumber = employee.PhoneNumber,
                IsActive = true, // Default value if needed
                CreatedAt = DateTime.UtcNow
            };

           var empId= await _repository.AddAsync(emp);

            return empId;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }


        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync()
        {
            var employees = await _repository.GetAllAsync();

            return employees.Select(emp => new EmployeeDTO
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                JobTitle = emp.JobTitle,
                DepartmentId = emp.DepartmentId,
                DepartmentName = emp.Department?.Name // Avoid circular reference
            }).ToList();
        }


        public async Task<EmployeeDTO?> GetByIdAsync(int id)
        {
            var emp = await _repository.GetByIdAsync(id);
            if (emp != null) {

                return new EmployeeDTO
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email,
                    PhoneNumber = emp.PhoneNumber,
                    JobTitle = emp.JobTitle,
                    DepartmentId = emp.DepartmentId,
                    DepartmentName = emp.Department?.Name // Avoid circular reference
                };
              }
            return null;
        }
        public async Task<EmployeeUpdateDTO?> UpdateAsync(EmployeeUpdateDTO employeeDto)
        {
            var emp = await _repository.GetByIdAsync(employeeDto.Id);
            if (emp == null)
            {
                return null; // Employee not found
            }

            // Update the existing entity with new values
            emp.FirstName = employeeDto.FirstName;
            emp.LastName = employeeDto.LastName;
            emp.Email = employeeDto.Email;
            emp.PhoneNumber = employeeDto.PhoneNumber;
            emp.JobTitle = employeeDto.JobTitle;
            emp.DepartmentId = employeeDto.DepartmentId;

            await _repository.UpdateAsync(emp); // Save changes in repository

            // Return the updated employee details
            return new EmployeeUpdateDTO
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                JobTitle = emp.JobTitle,
                DepartmentId = emp.DepartmentId,
                DepartmentName = emp.Department?.Name // Avoid circular reference
            };
        }


    }
}

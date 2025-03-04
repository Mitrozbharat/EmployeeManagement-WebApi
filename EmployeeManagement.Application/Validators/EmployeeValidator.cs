using EmployeeManagement.Application.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Validators
{
    public  class EmployeeValidator : AbstractValidator<EmployeeCreateDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("Employee Name is required")
                .MaximumLength(50).WithMessage("Maximum length is 50 characters");

            RuleFor(e => e.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID is required");
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
 }

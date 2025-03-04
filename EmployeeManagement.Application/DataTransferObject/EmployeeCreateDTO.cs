using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DataTransferObject
{
    public class EmployeeCreateDTO
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}

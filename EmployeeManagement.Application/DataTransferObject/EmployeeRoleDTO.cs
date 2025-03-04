using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DataTransferObject
{
    public class EmployeeRoleDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}

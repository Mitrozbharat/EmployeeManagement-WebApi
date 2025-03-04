using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Infrastructure.Entities;

public partial class TblEmployeeRole
{
    [Key]
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int RoleId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("TblEmployeeRoles")]
    public virtual TblEmployee Employee { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("TblEmployeeRoles")]
    public virtual TblRole Role { get; set; } = null!;
}

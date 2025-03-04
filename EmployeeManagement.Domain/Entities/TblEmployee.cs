using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Infrastructure.Entities;

public partial class TblEmployee
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    public string JobTitle { get; set; } = null!;

    public int DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("TblEmployees")]
    public virtual TblDepartment Department { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<TblEmployeeRole> TblEmployeeRoles { get; set; } = new List<TblEmployeeRole>();
}

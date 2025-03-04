using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Infrastructure.Entities;

public partial class TblRole
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<TblEmployeeRole> TblEmployeeRoles { get; set; } = new List<TblEmployeeRole>();
}

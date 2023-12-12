using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Common;

public class BaseEntity
{
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual long Id { get; set; }
}
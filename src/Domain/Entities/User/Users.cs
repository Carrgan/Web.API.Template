using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities.User;

public class Users: BaseEntity
{
    [MaxLength(20)] public string Name { get; set; }
    [MaxLength(50)] public string Email { get; set; }
}
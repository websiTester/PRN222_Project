using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.DTO.RoleDto
{
    public partial class RoleGet
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int[]? Permissions { get; set; }
    }
}

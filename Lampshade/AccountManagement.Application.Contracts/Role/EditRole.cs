﻿using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace AccountManagement.Application.Contracts.Role
{
    public class EditRole : CreateRole
    {
        public long Id { get; set; }
        public List<PermissionsDto> MappedPermissions { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Dtos.Auth.User
{
    public class UserDto
    {
        public int Id { get; set; } = default!;
        public string UserName { get; set; } = default!;
        //public string FullName { get; set; }
        public string Email { get; set; } = default!;
    }
}

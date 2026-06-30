using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Entities.Users
{
    public class CreateUserCommand
    {
        public string Name { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;
    }

}

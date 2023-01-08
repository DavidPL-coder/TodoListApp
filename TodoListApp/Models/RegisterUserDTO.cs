﻿using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class RegisterUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

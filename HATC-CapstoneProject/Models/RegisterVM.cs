﻿using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.ComponentModel.DataAnnotations;

namespace HATC_CapstoneProject.Models
{
    public class RegisterVM
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

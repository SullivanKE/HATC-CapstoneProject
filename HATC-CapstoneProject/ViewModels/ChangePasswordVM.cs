﻿namespace HATC_CapstoneProject.ViewModels
{
    public class ChangePasswordVM
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
    }
}
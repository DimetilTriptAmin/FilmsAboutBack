﻿using System.ComponentModel.DataAnnotations;

namespace FilmsAboutBack.DataAccess.DTO.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}

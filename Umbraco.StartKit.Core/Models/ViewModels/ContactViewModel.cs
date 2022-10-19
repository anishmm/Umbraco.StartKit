﻿using System.ComponentModel.DataAnnotations;


namespace Umbraco.StartKit.Core.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "toEmail is required")]
        public string toEmail { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Your message must be 500 characters or less")]
        public string Message { get; set; }
    }
}

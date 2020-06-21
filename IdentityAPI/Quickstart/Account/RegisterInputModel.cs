// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.ComponentModel.DataAnnotations;
using IdentityAPI.Models;

namespace IdentityServer4.Quickstart.UI
{
    public class RegisterInputModel
    {
        [Required]
        [RegularExpression(@"^[a-z]*[0-9]*$", ErrorMessage = "Please enter the format:a-z")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter the format: the first letter must be uppercase, the letter has no number")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 11")]
        [RegularExpression(@"^[0][0-9]{9,10}$", ErrorMessage = "Please enter the number")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Please enter the number")]
        public string IdentityCard { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
        public string selectGender { get; set; }

    }
}
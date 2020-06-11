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
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityCard { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

    }
}
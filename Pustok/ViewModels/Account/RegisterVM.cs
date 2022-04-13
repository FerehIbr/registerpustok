using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string SurName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

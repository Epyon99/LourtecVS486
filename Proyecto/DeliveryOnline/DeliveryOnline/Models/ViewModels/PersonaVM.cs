using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryOnline.Models.ViewModels
{
    public class PersonaVM
    {
        public string Id { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Compare("Email")]
        public string EmailConfirmed { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Compare("PhoneNumber")]
        public string PhoneNumberConfirmed { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryOnline.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
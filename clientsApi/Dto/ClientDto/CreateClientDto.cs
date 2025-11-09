using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace clientsApi.Dto
{
    public class CreateClientDto
    {
        [Required]
        [MaxLength(80, ErrorMessage = "Name cannot be longer than 80 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Company Name cannot be longer than 30 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "Phone Number cannot be longer than 15 characters")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

    }
}
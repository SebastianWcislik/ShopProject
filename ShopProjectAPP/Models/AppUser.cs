using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net;

namespace ShopProjectAPP.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName   { get; set; }
        public string Email {  get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
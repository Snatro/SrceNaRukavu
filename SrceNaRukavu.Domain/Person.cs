using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Role? Role { get; set; }
        public int RoleId { get; set; }     
        public string Email { get; set; }
        public string? Telephone { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }   
        public string? Token { get; set; }
        public ICollection<Reservation>? Reservations{ get; set; }
        
    }
}

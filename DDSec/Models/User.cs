using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BadDDSec.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int BirthYear { get; set; }
        [Required]
        public Guid Id { get; private set; }

        public string FullName {
            get { return $"{LastName}, {FirstName}"; }
            set
            {
                string[] fullName = value.Split(',');
                FirstName = fullName[1].Trim();
                LastName = fullName[0].Trim();
            }
        } 


        public User()
        {
            Id = Guid.NewGuid();
        }
        public User(string firstName, string lastName, string email, int birthYear, Guid? id = null) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthYear = birthYear;
            if (id != null)
                Id = (Guid)id;
        }
    }
}

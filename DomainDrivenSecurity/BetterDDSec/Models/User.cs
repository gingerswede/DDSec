using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDDSec.Models
{
    public class User
    {
        [Required]
        public Name FirstName { get; set; }
        [Required]
        public Name LastName { get; set; }
        [Required]
        [EmailAddress]
        public Email Email { get; set; }
        [Required]
        public Year BirthYear { get; set; }
        [Key]
        [Required]
        public Guid Id { get; private set; }

        public (bool validationResult, ValidationResult[] validationMessages) IsValid => Validate();


        public string FullName
        {
            get { return $"{LastName}, {FirstName}"; }
            set
            {
                string[] fullName = value.Split(',');
                FirstName = new Name(fullName[1].Trim());
                LastName = new Name(fullName[0].Trim());
            }
        }

        public User()
        {
            Id = Guid.NewGuid();
        }
        public User(Name firstName, Name lastName, Email email, Year birthYear, Guid? id = null) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthYear = birthYear;
            if (id != null)
                Id = (Guid)id;
        }

        private (bool validationResult, ValidationResult[] validationMessages) Validate()
        {
            List<ValidationResult> valResult = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(this, new ValidationContext(this), valResult);

            return (result, valResult.ToArray());
        }
    }
}


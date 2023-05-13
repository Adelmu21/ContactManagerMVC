using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsData
{
    public class Contact
    {
        
        [Required(ErrorMessage = "Please enter a Contact Id.")]
        [Display(Name = "Contact ID")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }


        [Display(Name = "Category")]
        public string CategoryId { get; set; }
        public Category? Category { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? Created { get; set; } = DateTime.Now;
    }
}

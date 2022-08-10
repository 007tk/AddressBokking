using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Application
{
    public class ContactDto
    {
        /// <summary>
        /// Get and set contact id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get & set contact name.
        /// </summary>
        [Display(Name = "Contact Name:")]
        [Required(ErrorMessage = "Please enter contact name")]
        public string ContactName { get; set; }

        /// <summary>
        /// Get & set contact surname.
        /// </summary>
        [Display(Name = "Contact Surname:")]
        [Required(ErrorMessage = "Please enter contact surname")]
        public string ContactSurname { get; set; }


        /// <summary>
        /// Get & set Age
        /// </summary>
        [Display(Name = "Contact Age:")]
        [Required(ErrorMessage = "Please enter age")]
        public int Age { get; set; }

        /// <summary>
        /// Get & set date of birth.
        /// </summary>
        [Display(Name = "Date of Birth:")]
        [Required(ErrorMessage = "Please enter date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Get & set contact number.
        /// </summary>
        [Display(Name = "Contact Number:")]
        [Required(ErrorMessage = "Please enter contact number")]
        public string ContactNumber { get; set; }

        /// <summary>
        /// Get & set address
        /// </summary>
        [Display(Name = "Address:")]
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        /// <summary>
        /// Get & set isDeleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

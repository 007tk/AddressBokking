using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Application.DTOs
{
    public class CsvContactsDto
    {
        /// <summary>
        /// Get & set contact name.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Get & set contact surname.
        /// </summary>
        public string ContactSurname { get; set; }


        /// <summary>
        /// Get & set Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Get & set date of birth.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Get & set contact number.
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// Get & set address
        /// </summary>
        public string Address { get; set; }

    }
}

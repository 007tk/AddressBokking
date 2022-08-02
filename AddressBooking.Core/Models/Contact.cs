using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBooking.Core
{
    /// <summary>
    /// Contact entity
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Get and set contact id.
        /// </summary>
        public int Id { get; set; }

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
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Get & set isDeleted.
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}

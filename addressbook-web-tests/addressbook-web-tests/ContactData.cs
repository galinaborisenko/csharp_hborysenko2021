using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class ContactData
    {
        private string firstName;
        private string lastName;
        private string middleName; //not mandatory field for ContactData, this why we not add to constructor 

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Firstname
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }



    }
}

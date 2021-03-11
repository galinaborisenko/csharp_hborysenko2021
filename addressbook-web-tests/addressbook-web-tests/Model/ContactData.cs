using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public override int GetHashCode()
        {
            return (Firstname.GetHashCode() + Lastname.GetHashCode());
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) //nothing with compare to
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) //two links point at the same object 
            {
                return true;
            }
            return (Lastname == other.Lastname); //if First and Last name the same - mean the same object for us
        }

        public override string ToString()
        {
            return "First Name:" + Firstname + " " + "Last Name:" + Lastname;
        }

        //sort list: other - with who compare, 1-this>other, 0-this=other, -1-this<other
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public string Firstname { get; set; }      

        public string Lastname { get; set;  }
        
        public string Middlename { get; set; }  
    }
}

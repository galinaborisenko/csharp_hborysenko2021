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
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

       //which objects are equal, use if hashcode returns different values for two objects
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
            if (Lastname !=other.Lastname) //false if Lastname different
            {
                return false;
            }
            return Firstname == other.Firstname; //if First and Last name the same - mean the same object for us
        }

        //строковое представление обекта contact
        public override string ToString()
         {
            return "LastName:" + Lastname +" "+  "FirstName:" + Firstname;
        }

        //sort list: 1-this>other, 0-this=other, -1-this<other
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else 
            {
                return Lastname.CompareTo(other.Lastname);
            }          
        }

        public string Firstname { get; set; }      

        public string Lastname { get; set;  }
        
        public string Middlename { get; set; }

        public string Id { get; set; }
    }
}

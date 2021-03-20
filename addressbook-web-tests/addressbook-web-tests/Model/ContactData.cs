using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string contactInfo;
        public string firstLastName;

        public ContactData(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public ContactData(string firstLastName)
        {
            FirstLastName = firstLastName;
        }

        public ContactData()
        {
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
            if (Lastname != other.Lastname) //false if Lastname different
            {
                return false;
            }
            return Firstname == other.Firstname; //if First and Last name the same - mean the same object for us
        }

        //строковое представление обекта contact
        public override string ToString()
        {
            return "LastName:" + Lastname + " " + "FirstName:" + Firstname;
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

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        
        public string AllPhones 
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            }      
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email)+CleanUp(Email2)+ CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string FirstLastName
        {
            get
            {
                if (firstLastName != null)
                {
                    return firstLastName;
                }
                else
                {
                    return (CleanUp(Firstname)+CleanUp(Lastname)).Trim();
                }
            }
            set
            {
                firstLastName = value;
            }
        }

        public string ContactInfo
        {
            get
            {
                if (ContactInfo != null)
                {
                    return contactInfo;
                }
                else
                {
                    return (CleanUp(Address) + CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + 
                        CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                contactInfo = value;
            }
        }

        private string CleanUp(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[+_ -()]", "") +"\r\n";

        }
    }
}

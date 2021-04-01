using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;


namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        private string contactDetailedInfo;

        public ContactData(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
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

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        
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
                    return 
                        (CleanUpForContactInfoTableAndEditFormTest(HomePhone) +
                        CleanUpForContactInfoTableAndEditFormTest(MobilePhone) + 
                        CleanUpForContactInfoTableAndEditFormTest(WorkPhone)).Trim();
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
                    return 
                        (CleanUpForContactInfoTableAndEditFormTest(Email)+ 
                        CleanUpForContactInfoTableAndEditFormTest(Email2)+
                        CleanUpForContactInfoTableAndEditFormTest(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string ContactDetailedInfo
        {
            get
            {
                if (contactDetailedInfo != null)
                {
                    return contactDetailedInfo;
                }
                else
                {
                    return

                        (CleanUpForContactInfoEditFormAndDetailsPageTest(Firstname) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(Middlename) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(Lastname) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(Address) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(HomePhone) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(MobilePhone) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(WorkPhone) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest (Email) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(Email2) +
                        CleanUpForContactInfoEditFormAndDetailsPageTest(Email3)).Trim();
                }
            }
            set
            {
                contactDetailedInfo = value;
            }
        }

        private string CleanUpForContactInfoTableAndEditFormTest(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[+_ -()]", "") + "\r\n";
        }

        private string CleanUpForContactInfoEditFormAndDetailsPageTest(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            else if (data == Firstname || data == Middlename)
            {
                return Regex.Replace(data, "[+_()]", "") + " ";
            }
            else if (data == Address)
            {
                return "\r\n" + Regex.Replace(data, "[+_()]", "") + "\r\n";
            }
            else if (data == HomePhone)
            {
                return "\r\nH: " + Regex.Replace(data, "[+_()]", "");
            }
            else if (data == MobilePhone)
            {
                return "\r\nM: " + Regex.Replace(data, "[+_()]", "");
            }
            else if (data == WorkPhone)
            {
                return "\r\nW: " + Regex.Replace(data, "[+_()]", "") + "\r\n";
            }
            else if (data == Email || data == Email2 || data == Email3)
            {
                return "\r\n" + Regex.Replace(data, "[+_()]", "");
            }
            return Regex.Replace(data, "[+_()]", "");
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            };
        }
    }
}

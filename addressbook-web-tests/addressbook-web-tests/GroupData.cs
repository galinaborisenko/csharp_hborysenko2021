﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class GroupData
    {
        private string name;
        private string header = ""; //not mandatory field for GroupData, this why we not add to constructor 
        private string footer = ""; //not mandatory field for GroupData, this why we not add to constructor 

        public GroupData(string name)
        {
            this.name = name;
        }

        
        public string Name
        {
            get 
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }



       public string Footer
            {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}

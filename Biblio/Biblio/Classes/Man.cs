using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Biblio
{
    public class Man
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Man (string lastName, string name, string secondName, string address,
            string phonenumber)
        {

            this.LastName = lastName;
            this.Name = name;
            this.SecondName = secondName;
            this.Address = address;
            this.PhoneNumber = phonenumber;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => this.FirstName + ' ' + this.LastName;
    }
}

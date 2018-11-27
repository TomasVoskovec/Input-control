using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input_control
{
    class Class
    {
        public string Name { get; set; }
        public List<Person> People { get; set; }

        public Class(string name, List<Person> people)
        {
            this.Name = name;
            this.People = people;
        }
    }
}

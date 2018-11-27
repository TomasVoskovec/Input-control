using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input_control
{
    class School
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; }

        public School(string name, List<Class> classes)
        {
            this.Name = name;
            this.Classes = classes;
        }
    }
}

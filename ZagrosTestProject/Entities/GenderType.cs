using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagrosTestProject.Entities
{
    public class GenderType
    {
        //public GenderType()
        //{
        //    Person = new HashSet<Person>();
        //    Personnel = new HashSet<Personnel>();
        //}

        public int Id { get; set; }
        public string GenderTitle { get; set; }
        public string GenderDescription { get; set; }

        public ICollection<Person> Person { get; set; }
        public ICollection<Personnel> Personnel { get; set; }
    }
}


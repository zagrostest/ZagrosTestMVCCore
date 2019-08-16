using System;
using System.Collections.Generic;

namespace ZagrosTestProject
{
    public partial class MaritalStatusType
    {
        //public MaritalStatusType()
        //{
        //    Person = new HashSet<Person>();
        //    Personnel = new HashSet<Personnel>();
        //}

        public int Id { get; set; }
        public string MaritalStatusTitle { get; set; }
        public string MaritalStatusDescription { get; set; }

        public ICollection<Person> Person { get; set; }
        public ICollection<Personnel> Personnel { get; set; }
    }
}

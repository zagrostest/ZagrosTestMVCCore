using System;
using System.Collections.Generic;

namespace ZagrosTestProject
{
    public partial class PositionType
    {
        //public PositionType()
        //{
        //    Personnel = new HashSet<Personnel>();
        //}

        public int Id { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDescription { get; set; }

        public ICollection<Personnel> Personnel { get; set; }
    }
}

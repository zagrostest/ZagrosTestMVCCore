using System;
using System.Collections.Generic;

namespace ZagrosTestProject
{
    public partial class EducationDegreeType
    {
        //public EducationDegreeType()
        //{
        //    Education = new HashSet<Education>();
        //}

        public int Id { get; set; }
        public string EducationDegreeTitle { get; set; }
        public string EducationDegreeDescription { get; set; }

        public ICollection<Education> Education { get; set; }
    }
}

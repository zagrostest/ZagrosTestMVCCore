using System;
using System.Collections.Generic;

namespace ZagrosTestProject
{
    public partial class Education
    {
        public int Id { get; set; }
        public int PersonnelId { get; set; }
        public int EducationDegreeTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public EducationDegreeType EducationDegreeType { get; set; }
        public Personnel Personnel { get; set; }
    }
}

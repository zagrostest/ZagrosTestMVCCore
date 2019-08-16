using System;
using System.Collections.Generic;
using ZagrosTestProject.Entities;

namespace ZagrosTestProject
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public DateTime? Birthdate { get; set; }
        public int MaritalStatusId { get; set; }

        public MaritalStatusType MaritalStatus { get; set; }
        public GenderType Gender { get; set; }
    }
}

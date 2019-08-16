using CustomCookieAuthentication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagrosTestProject.Entities
{
    public class ASPCoreDBContext : DbContext
    {
        public ASPCoreDBContext(DbContextOptions<ASPCoreDBContext> options)
            : base(options)
        { }

        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationDegreeType> EducationDegreeTypes { get; set; }
        public DbSet<GenderType> GenderTypes { get; set; }
        public DbSet<MaritalStatusType> MaritalStatusTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<PositionType> PositionTypes { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}


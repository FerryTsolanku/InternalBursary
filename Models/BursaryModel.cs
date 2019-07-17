using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Internal_Bursary.Models
{
    public class BursaryModel
    {
        [Key]
        public int PassID { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }

    }

    public class EmployeeDetails
    {
        [Key]
        public int EMPID { get; set; }
        public int PassID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string BU { get; set; }
        public string Center { get; set; }

        //public static implicit operator EmployeeDetails(int v)
        //{
        //    throw new NotImplementedException();
        //}


        //public List<EmployeeDetails> Employee { get; set; }
    }

    public class CurriculumDetails
    {
        [Key]
        public int SubCrseID { get; set; }
        public int EMPID { get; set; }
        public string SubCrse { get; set; }
        public int PassSubj { get; set; }
        public DateTime YrPass { get; set; }
        public int FailSubj { get; set; }
        public DateTime YrFail { get; set; }
        public double AGBurAmountPaid { get; set; }
        public double AGLoanPaid { get; set; }

    }
    public class Subjects
    {
        [Key]
        public string SubjID { get; set; }
        public int EMPID { get; set; }
        public DateTime Year { get; set; }
        public string Subjectss { get; set; }
        public double CostPer { get; set; }
        public int SubCrseID { get; set; }
    }

    //public class EMpCurr
    //{
    //    public EmployeeDetails EmployeeDetails { get; set; }
    //    public CurriculumDetails CurriculumDetails { get; set; }
    //}
    public class BursaryDBContext : DbContext
    {
        public DbSet<BursaryModel> Bursaries { get; set; }
        public DbSet<EmployeeDetails> Employee { get; set; }
        public DbSet<CurriculumDetails> Curriculum { get; set; }
        public DbSet<Subjects> Subs { get; set; }
    }

    public class EMpCurr
    {
        public List<EmployeeDetails> EmployeeDetail { get; set; }
        public List<CurriculumDetails> CurriculumDetail { get; set; }
    }
}

  
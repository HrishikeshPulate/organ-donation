using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EF_Database : DbContext
    {
        // Your context has been configured to use a 'EF_Database' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'organ_donation.EF_Database' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EF_Database' 
        // connection string in the application configuration file.
        public EF_Database() : base("MyDbConStr")
        {
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Userinfo> Userinfos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Accepter> Accepters { get; set; }
        public virtual DbSet<Nominee> Nominees { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
     
        public virtual DbSet<CasePool> CasePools { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
    }


    public class Userinfo
    {
        [Key]
        public int USER_ID { get; set; }
        [Required]
        public string USER_NAME { get; set; }
        [Required]
        public string PASSWORD { get; set; }
        [ForeignKey("ROLE_ID")]
        [Required]
        public int RoleId { get; set; }
        public Role ROLE_ID { get; set; }
    }
    public class Role
    {
        [Key]
        public int ROLE_ID { get; set; }
        [Required]
        public string ROLE_NAME { get; set; }
    }
    public class Accepter
    {
        [Key]
        public int ACEEPTER_ID { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string REQUIREMENT { get; set; }
        [Required]
        public int AGE { get; set; }
        [Required]
        public DateTime DATE { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string LOCATION { get; set; }
        [Required]
        public string BLOOD_GROUP { get; set; }
        [Required]
        public string CONTACT_NUMBER { get; set; }
        [Required]
        public string STATUS { get; set; }
        [ForeignKey("USER_ID")]
        [Required]
        public int UserId { get; set; }
        public Userinfo USER_ID { get; set; }
    }
    public class Nominee
    {
        [Key]
        public int NOMINEE_ID { get; set; }
        [Required]
        public string DONOR_NAME { get; set; }
        [Required]
        public string NOMINEE_NAME { get; set; }
        [Required]
        public int DONOR_AGE { get; set; }
        [Required]
        public DateTime DATE { get; set; }
        [Required]
        public string DONOR_GENDER { get; set; }
        [Required]
        public string LOCATION { get; set; }
        [Required]
        public string BLOOD_GROUP { get; set; }
        [Required]
        public string CONTACT_NUMBER { get; set; }
        [Required]
        public string STATUS { get; set; }
        [ForeignKey("USER_ID")]
        [Required]
        public int UserId { get; set; }
        public Userinfo USER_ID { get; set; }
    }
    public class Doctor
    {
        [Key]
        public int DOCTOR_ID { get; set; }
        [Required]
        public string DOCTOR_NAME { get; set; }
        [Required]
        public string CONTACT_NUMBER { get; set; }
        [Required]
        public string STATUS { get; set; }
        [ForeignKey("UInfo")]
        [Required]
        public int UserId { get; set; }
        public Userinfo UInfo { get; set; }
    }
    public class Manager
    {
        [Key]
        public int MANAGER_ID { get; set; }
        [Required]
        public string MANAGER_NAME { get; set; }
        [Required]
        public string CONTACT_NUMBER { get; set; }
        [ForeignKey("USER_ID")]
        [Required]
        public int UserId { get; set; }
        public Userinfo USER_ID { get; set; }
    }
   
    public class CasePool
    {
        [Key]
        public int CASE_ID { get; set; }
        [ForeignKey("ACCEPTER_ID")]
        
        public int? AccepterId { get; set; }
        public Accepter ACCEPTER_ID { get; set; }
        [ForeignKey("DONOR_ID")]
        [Required]
        public int DonorId { get; set; }
        public Nominee DONOR_ID { get; set; }
        public string ORGANS { get; set; }
        [ForeignKey("DOCTOR_ID")]
      
        public int? DoctorId { get; set; }
        public Doctor DOCTOR_ID { get; set; }
        public string STATUS { get; set; }
    }
    public class Appointment
    {
        [Key]
        public int APPOINTMENT_ID { get; set; }

        [ForeignKey("CASE_ID")]
        public int CaseId { get; set; }
        public CasePool CASE_ID { get; set; }
       
        public string STATUS { get; set; }
        [Required]
        public string SLOT { get; set; }
        [Required]
        public DateTime BOOKING_DATE { get; set; }
    }
}
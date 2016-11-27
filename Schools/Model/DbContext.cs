namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db : DbContext
    {
        public Db()
            : base("data source=ENVY\\SQLEXPRESS;initial catalog=School;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            //COMPUTER-ой\\SQLEXPRESS
            //ENVY\\SQLEXPRESS
        }

        public virtual DbSet<rbd_Address> rbd_Address { get; set; }
        public virtual DbSet<rbd_Areas> rbd_Areas { get; set; }
        public virtual DbSet<rbd_Coordinates> rbd_Coordinates { get; set; }
        public virtual DbSet<rbd_CurrentRegion> rbd_CurrentRegion { get; set; }
        public virtual DbSet<rbd_Governments> rbd_Governments { get; set; }
        public virtual DbSet<rbd_PCenters> rbd_PCenters { get; set; }
        public virtual DbSet<rbd_SchoolAddress> rbd_SchoolAddress { get; set; }
        public virtual DbSet<rbd_Schools> rbd_Schools { get; set; }
        public virtual DbSet<rbd_Stations> rbd_Stations { get; set; }
        public virtual DbSet<rbd_Townships> rbd_Townships { get; set; }
        public virtual DbSet<rbdc_AddressTypes> rbdc_AddressTypes { get; set; }
        public virtual DbSet<rbdc_BuildingTypes> rbdc_BuildingTypes { get; set; }
        public virtual DbSet<rbdc_LocalityTypes> rbdc_LocalityTypes { get; set; }
        public virtual DbSet<rbdc_Regions> rbdc_Regions { get; set; }
        public virtual DbSet<rbdc_SchoolKinds> rbdc_SchoolKinds { get; set; }
        public virtual DbSet<rbdc_SchoolProperties> rbdc_SchoolProperties { get; set; }
        public virtual DbSet<rbdc_SchoolTypes> rbdc_SchoolTypes { get; set; }
        public virtual DbSet<rbdc_StreetTypes> rbdc_StreetTypes { get; set; }
        public virtual DbSet<rbdc_TimeZones> rbdc_TimeZones { get; set; }
        public virtual DbSet<rbdc_TownTypes> rbdc_TownTypes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<rbd_Address>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Address>()
                .Property(e => e.LocalityName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Address>()
                .Property(e => e.StreetName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Address>()
                .Property(e => e.BuildingNumber)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Address>()
                .HasMany(e => e.rbd_SchoolAddress)
                .WithRequired(e => e.rbd_Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.LawAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.ChargeFIO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.Phones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.Mails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .Property(e => e.WWW)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Areas>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbd_Areas)
                .HasForeignKey(e => e.AreaFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Areas>()
                .HasMany(e => e.rbd_Stations)
                .WithRequired(e => e.rbd_Areas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Coordinates>()
                .HasMany(e => e.rbd_Address)
                .WithOptional(e => e.rbd_Coordinates)
                .HasForeignKey(e => e.CoordinatesID);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOILawAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIProperty)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIDPosition)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIDFio)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIPhones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIFaxs)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.RCOIEMails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.GEKAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.GEKDFio)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.GEKPhones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.GEKFaxs)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.GEKEMails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .Property(e => e.EGEWWW)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_CurrentRegion>()
                .HasMany(e => e.rbd_Governments)
                .WithRequired(e => e.rbd_CurrentRegion)
                .HasForeignKey(e => new { e.RegionID, e.REGION })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.GovernmentName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.LawAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.ChargeFIO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.Phones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.Mails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.WWW)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.ChargePosition)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.Faxes)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.SpecialistFIO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.SpecialistMails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .Property(e => e.SpecialistPhones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Governments>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbd_Governments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Governments>()
                .HasMany(e => e.rbd_Stations)
                .WithRequired(e => e.rbd_Governments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_PCenters>()
                .Property(e => e.PCenterName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_PCenters>()
                .Property(e => e.PCenterAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_PCenters>()
                .Property(e => e.ChargeFIO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_PCenters>()
                .Property(e => e.Phones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_PCenters>()
                .Property(e => e.Mails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.SchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.LawAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.DPosition)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.Phones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.Faxs)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.Mails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.ChargeFIO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.WWW)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.LicNum)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.LicRegNo)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.LicIssueDate)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.LicFinishingDate)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.AccCertNum)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.AccCertRegNo)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.AccCertIssueDate)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.AccCertFinishingDate)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.SReserve1)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.SReserve2)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Schools>()
                .HasMany(e => e.rbd_SchoolAddress)
                .WithRequired(e => e.rbd_Schools)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Schools>()
                .HasMany(e => e.rbd_Stations)
                .WithOptional(e => e.rbd_Schools)
                .HasForeignKey(e => e.SchoolFK);

            modelBuilder.Entity<rbd_Stations>()
                .Property(e => e.StationName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Stations>()
                .Property(e => e.StationAddress)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Stations>()
                .Property(e => e.Phones)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Stations>()
                .Property(e => e.Mails)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Townships>()
                .Property(e => e.TownshipName)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Townships>()
                .Property(e => e.OCATO)
                .IsUnicode(false);

            modelBuilder.Entity<rbd_Townships>()
                .HasMany(e => e.rbd_Address)
                .WithRequired(e => e.rbd_Townships)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbd_Townships>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbd_Townships)
                .HasForeignKey(e => e.TownshipFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_AddressTypes>()
                .Property(e => e.AddressTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_AddressTypes>()
                .HasMany(e => e.rbd_SchoolAddress)
                .WithRequired(e => e.rbdc_AddressTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_BuildingTypes>()
                .Property(e => e.BuildingTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_BuildingTypes>()
                .Property(e => e.BuildingTypeShName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_BuildingTypes>()
                .HasMany(e => e.rbd_Address)
                .WithRequired(e => e.rbdc_BuildingTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_LocalityTypes>()
                .Property(e => e.LocalityTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_LocalityTypes>()
                .Property(e => e.LocalityTypeShName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_LocalityTypes>()
                .HasMany(e => e.rbd_Address)
                .WithRequired(e => e.rbdc_LocalityTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .Property(e => e.RegionName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_Address)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_Areas)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_CurrentRegion)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_PCenters)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_SchoolAddress)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_Stations)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_Regions>()
                .HasMany(e => e.rbd_Townships)
                .WithRequired(e => e.rbdc_Regions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_SchoolKinds>()
                .Property(e => e.SchoolKindName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_SchoolKinds>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbdc_SchoolKinds)
                .HasForeignKey(e => e.SchoolKindFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_SchoolProperties>()
                .Property(e => e.SchoolPropertyName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_SchoolProperties>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbdc_SchoolProperties)
                .HasForeignKey(e => e.SchoolPropertyFk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_SchoolTypes>()
                .Property(e => e.SchoolTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_SchoolTypes>()
                .HasMany(e => e.rbdc_SchoolKinds)
                .WithRequired(e => e.rbdc_SchoolTypes)
                .HasForeignKey(e => e.SchoolTypeFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_StreetTypes>()
                .Property(e => e.StreetTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_StreetTypes>()
                .Property(e => e.StreetTypeShName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_StreetTypes>()
                .HasMany(e => e.rbd_Address)
                .WithRequired(e => e.rbdc_StreetTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rbdc_TimeZones>()
                .Property(e => e.TimeZoneName)
                .IsFixedLength();

            modelBuilder.Entity<rbdc_TimeZones>()
                .Property(e => e.TimeZoneNum)
                .HasPrecision(10, 2);

            modelBuilder.Entity<rbdc_TownTypes>()
                .Property(e => e.TownTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<rbdc_TownTypes>()
                .HasMany(e => e.rbd_Schools)
                .WithRequired(e => e.rbdc_TownTypes)
                .HasForeignKey(e => e.TownTypeFK)
                .WillCascadeOnDelete(false);
        }
    }
}

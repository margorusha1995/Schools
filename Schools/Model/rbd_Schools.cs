namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_Schools
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_Schools()
        {
            rbd_SchoolAddress = new HashSet<rbd_SchoolAddress>();
            rbd_Stations = new HashSet<rbd_Stations>();
        }

        [Key]
        public Guid SchoolID { get; set; }

        public Guid GovernmentID { get; set; }

        public int SchoolCode { get; set; }

        [StringLength(1024)]
        public string SchoolName { get; set; }

        public short SchoolKindFK { get; set; }

        public short SchoolPropertyFk { get; set; }

        public Guid AreaFK { get; set; }

        public int TownTypeFK { get; set; }

        [Required]
        public string LawAddress { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(150)]
        public string DPosition { get; set; }

        [Required]
        [StringLength(150)]
        public string FIO { get; set; }

        [Required]
        [StringLength(80)]
        public string Phones { get; set; }

        [StringLength(80)]
        public string Faxs { get; set; }

        [Required]
        [StringLength(255)]
        public string Mails { get; set; }

        public int People11 { get; set; }

        public int People9 { get; set; }

        [Required]
        [StringLength(150)]
        public string ChargeFIO { get; set; }

        [StringLength(255)]
        public string WWW { get; set; }

        [StringLength(80)]
        public string LicNum { get; set; }

        [StringLength(80)]
        public string LicRegNo { get; set; }

        [StringLength(10)]
        public string LicIssueDate { get; set; }

        [StringLength(10)]
        public string LicFinishingDate { get; set; }

        [StringLength(255)]
        public string AccCertNum { get; set; }

        [StringLength(255)]
        public string AccCertRegNo { get; set; }

        [StringLength(10)]
        public string AccCertIssueDate { get; set; }

        [StringLength(10)]
        public string AccCertFinishingDate { get; set; }

        public bool? isVirtualSchool { get; set; }

        [StringLength(255)]
        public string SReserve1 { get; set; }

        [StringLength(255)]
        public string SReserve2 { get; set; }

        public int DeleteType { get; set; }

        public bool IsTOM { get; set; }

        public int REGION { get; set; }

        [StringLength(255)]
        public string ShortName { get; set; }

        public int TownshipFK { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? ImportCreateDate { get; set; }

        public DateTime? ImportUpdateDate { get; set; }

        public int SchoolFlags { get; set; }

        public virtual rbd_Areas rbd_Areas { get; set; }

        public virtual rbd_Governments rbd_Governments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_SchoolAddress> rbd_SchoolAddress { get; set; }

        public virtual rbd_Townships rbd_Townships { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Stations> rbd_Stations { get; set; }

        public virtual rbdc_SchoolKinds rbdc_SchoolKinds { get; set; }

        public virtual rbdc_SchoolProperties rbdc_SchoolProperties { get; set; }

        public virtual rbdc_TownTypes rbdc_TownTypes { get; set; }
    }
}

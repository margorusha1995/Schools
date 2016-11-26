namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_Governments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_Governments()
        {
            rbd_Schools = new HashSet<rbd_Schools>();
            rbd_Stations = new HashSet<rbd_Stations>();
        }

        [Key]
        public Guid GovernmentID { get; set; }

        public Guid RegionID { get; set; }

        public int REGION { get; set; }

        public int GovernmentCode { get; set; }

        [Required]
        [StringLength(255)]
        public string GovernmentName { get; set; }

        [Required]
        [StringLength(255)]
        public string LawAddress { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(150)]
        public string ChargeFIO { get; set; }

        [Required]
        [StringLength(80)]
        public string Phones { get; set; }

        [Required]
        [StringLength(80)]
        public string Mails { get; set; }

        [StringLength(255)]
        public string WWW { get; set; }

        [Required]
        [StringLength(150)]
        public string ChargePosition { get; set; }

        [Required]
        [StringLength(80)]
        public string Faxes { get; set; }

        public int GType { get; set; }

        [Required]
        [StringLength(150)]
        public string SpecialistFIO { get; set; }

        [StringLength(80)]
        public string SpecialistMails { get; set; }

        [Required]
        [StringLength(255)]
        public string SpecialistPhones { get; set; }

        public int DeleteType { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? ImportCreateDate { get; set; }

        public DateTime? ImportUpdateDate { get; set; }

        public int? TimeZoneId { get; set; }

        public virtual rbd_CurrentRegion rbd_CurrentRegion { get; set; }

        public virtual rbdc_TimeZones rbdc_TimeZones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Schools> rbd_Schools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Stations> rbd_Stations { get; set; }
    }
}

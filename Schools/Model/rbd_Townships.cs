namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_Townships
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_Townships()
        {
            rbd_Address = new HashSet<rbd_Address>();
            rbd_Schools = new HashSet<rbd_Schools>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TownshipID { get; set; }

        public int REGION { get; set; }

        [Required]
        [StringLength(255)]
        public string TownshipName { get; set; }

        [Required]
        [StringLength(50)]
        public string OCATO { get; set; }

        public int? TimeZoneID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Address> rbd_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Schools> rbd_Schools { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }

        public virtual rbdc_TimeZones rbdc_TimeZones { get; set; }
    }
}

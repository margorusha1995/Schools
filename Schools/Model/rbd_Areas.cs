namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_Areas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_Areas()
        {
            rbd_Schools = new HashSet<rbd_Schools>();
            rbd_Stations = new HashSet<rbd_Stations>();
        }

        [Key]
        public Guid AreaID { get; set; }

        public int Region { get; set; }

        public int AreaCode { get; set; }

        [Required]
        [StringLength(255)]
        public string AreaName { get; set; }

        [StringLength(255)]
        public string LawAddress { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(150)]
        public string ChargeFIO { get; set; }

        [StringLength(80)]
        public string Phones { get; set; }

        [StringLength(255)]
        public string Mails { get; set; }

        [StringLength(255)]
        public string WWW { get; set; }

        public bool IsDeleted { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Schools> rbd_Schools { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Stations> rbd_Stations { get; set; }
    }
}

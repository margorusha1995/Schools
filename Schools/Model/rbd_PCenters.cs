namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_PCenters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_PCenters()
        {
            rbd_Stations = new HashSet<rbd_Stations>();
        }

        [Key]
        public Guid PCenterID { get; set; }

        public int REGION { get; set; }

        public int PCenterCode { get; set; }

        [Required]
        [StringLength(255)]
        public string PCenterName { get; set; }

        [Required]
        [StringLength(255)]
        public string PCenterAddress { get; set; }

        [Required]
        [StringLength(150)]
        public string ChargeFIO { get; set; }

        [Required]
        [StringLength(80)]
        public string Phones { get; set; }

        [Required]
        [StringLength(255)]
        public string Mails { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? ImportCreateDate { get; set; }

        public DateTime? ImportUpdateDate { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Stations> rbd_Stations { get; set; }
    }
}

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_CurrentRegion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_CurrentRegion()
        {
            rbd_Governments = new HashSet<rbd_Governments>();
        }

        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int REGION { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIName { get; set; }

        [Required]
        public string RCOILawAddress { get; set; }

        [Required]
        public string RCOIAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIProperty { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIDPosition { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIDFio { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIPhones { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIFaxs { get; set; }

        [Required]
        [StringLength(255)]
        public string RCOIEMails { get; set; }

        [StringLength(255)]
        public string GEKAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string GEKDFio { get; set; }

        [Required]
        [StringLength(255)]
        public string GEKPhones { get; set; }

        [Required]
        [StringLength(255)]
        public string GEKFaxs { get; set; }

        [Required]
        [StringLength(255)]
        public string GEKEMails { get; set; }

        [Required]
        [StringLength(255)]
        public string EGEWWW { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Governments> rbd_Governments { get; set; }
    }
}

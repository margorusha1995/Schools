namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbdc_StreetTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbdc_StreetTypes()
        {
            rbd_Address = new HashSet<rbd_Address>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StreetTypeID { get; set; }

        public int StreetTypeCode { get; set; }

        [Required]
        [StringLength(255)]
        public string StreetTypeName { get; set; }

        [Required]
        [StringLength(255)]
        public string StreetTypeShName { get; set; }

        public int SortBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Address> rbd_Address { get; set; }
    }
}

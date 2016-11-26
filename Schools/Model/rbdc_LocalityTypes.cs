namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbdc_LocalityTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbdc_LocalityTypes()
        {
            rbd_Address = new HashSet<rbd_Address>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocalityTypeID { get; set; }

        public int LocalityTypeCode { get; set; }

        [Required]
        [StringLength(255)]
        public string LocalityTypeName { get; set; }

        [Required]
        [StringLength(255)]
        public string LocalityTypeShName { get; set; }

        public int SortBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Address> rbd_Address { get; set; }
    }
}

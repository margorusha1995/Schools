namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbdc_SchoolProperties
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbdc_SchoolProperties()
        {
            rbd_Schools = new HashSet<rbd_Schools>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SchoolPropertyID { get; set; }

        public byte SchoolPropertyCode { get; set; }

        [StringLength(100)]
        public string SchoolPropertyName { get; set; }

        public int SortBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Schools> rbd_Schools { get; set; }
    }
}

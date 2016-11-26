namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbdc_SchoolKinds
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbdc_SchoolKinds()
        {
            rbd_Schools = new HashSet<rbd_Schools>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SchoolKindID { get; set; }

        public int SchoolTypeFK { get; set; }

        public int SchoolKindCode { get; set; }

        [StringLength(150)]
        public string SchoolKindName { get; set; }

        public int SortBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Schools> rbd_Schools { get; set; }

        public virtual rbdc_SchoolTypes rbdc_SchoolTypes { get; set; }
    }
}

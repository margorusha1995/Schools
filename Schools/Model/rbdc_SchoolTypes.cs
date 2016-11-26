namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbdc_SchoolTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbdc_SchoolTypes()
        {
            rbdc_SchoolKinds = new HashSet<rbdc_SchoolKinds>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SchoolTypeID { get; set; }

        public int SchoolTypeCode { get; set; }

        [Required]
        [StringLength(255)]
        public string SchoolTypeName { get; set; }

        public int SortBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbdc_SchoolKinds> rbdc_SchoolKinds { get; set; }
    }
}

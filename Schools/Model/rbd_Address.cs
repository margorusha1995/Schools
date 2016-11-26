namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rbd_Address()
        {
            rbd_SchoolAddress = new HashSet<rbd_SchoolAddress>();
            rbd_Stations = new HashSet<rbd_Stations>();
        }

        [Key]
        public Guid AddressID { get; set; }

        public int REGION { get; set; }

        [Required]
        [StringLength(16)]
        public string ZipCode { get; set; }

        public int LocalityTypeID { get; set; }

        [Required]
        [StringLength(255)]
        public string LocalityName { get; set; }

        public int StreetTypeID { get; set; }

        [Required]
        [StringLength(255)]
        public string StreetName { get; set; }

        public int BuildingTypeID { get; set; }

        [Required]
        [StringLength(255)]
        public string BuildingNumber { get; set; }

        public int TownshipID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? ImportCreateDate { get; set; }

        public DateTime? ImportUpdateDate { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid? CoordinatesID { get; set; }

        public virtual rbd_Coordinates rbd_Coordinates { get; set; }

        public virtual rbd_Townships rbd_Townships { get; set; }

        public virtual rbdc_BuildingTypes rbdc_BuildingTypes { get; set; }

        public virtual rbdc_LocalityTypes rbdc_LocalityTypes { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }

        public virtual rbdc_StreetTypes rbdc_StreetTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_SchoolAddress> rbd_SchoolAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rbd_Stations> rbd_Stations { get; set; }
    }
}

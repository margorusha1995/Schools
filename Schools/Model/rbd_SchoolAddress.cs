namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_SchoolAddress
    {
        [Key]
        public Guid SchoolAddressID { get; set; }

        public int REGION { get; set; }

        public Guid SchoolID { get; set; }

        public Guid AddressID { get; set; }

        public int AddressTypeID { get; set; }

        public int? AddressKind { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? ImportCreateDate { get; set; }

        public DateTime? ImportUpdateDate { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual rbd_Address rbd_Address { get; set; }

        public virtual rbd_Schools rbd_Schools { get; set; }

        public virtual rbdc_AddressTypes rbdc_AddressTypes { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }
    }
}

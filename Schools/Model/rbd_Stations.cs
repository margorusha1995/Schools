namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rbd_Stations
    {
        [Key]
        public Guid StationID { get; set; }

        public int REGION { get; set; }

        public Guid AreaID { get; set; }

        public int StationCode { get; set; }

        [Required]
        [StringLength(255)]
        public string StationName { get; set; }

        [StringLength(1000)]
        public string StationAddress { get; set; }

        public Guid? SchoolFK { get; set; }

        public Guid GovernmentID { get; set; }

        public int sVolume { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(255)]
        public string Phones { get; set; }

        [Required]
        [StringLength(255)]
        public string Mails { get; set; }

        public Guid? PCenterID { get; set; }

        public bool IsTOM { get; set; }

        public int DeleteType { get; set; }

        public int? AuditoriumsCount { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? ImportCreateDate { get; set; }

        public DateTime? ImportUpdateDate { get; set; }

        public int ExamForm { get; set; }

        public bool VideoControl { get; set; }

        public Guid? AddressID { get; set; }

        public int StationFlags { get; set; }

        public int? TimeZoneId { get; set; }

        public virtual rbd_Address rbd_Address { get; set; }

        public virtual rbd_Areas rbd_Areas { get; set; }

        public virtual rbd_Governments rbd_Governments { get; set; }

        public virtual rbd_PCenters rbd_PCenters { get; set; }

        public virtual rbd_Schools rbd_Schools { get; set; }

        public virtual rbdc_Regions rbdc_Regions { get; set; }
    }
}

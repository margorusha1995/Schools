namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GoogleCoordinates
    {
        public Guid id { get; set; }

        public double? longitude { get; set; }

        public double? latitude { get; set; }

        public Guid placeID { get; set; }
    }
}

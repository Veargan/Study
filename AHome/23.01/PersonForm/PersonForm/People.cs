namespace PersonForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class People
    {
        public int id { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public int age { get; set; }
    }
}

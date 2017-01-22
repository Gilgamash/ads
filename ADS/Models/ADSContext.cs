using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ADS.Models
{
    public class ADSContext : DbContext
    {
        public ADSContext() : base("name=ADSContext") { }
        public DbSet<DataModel> DataModels { get; set; }
    }
}
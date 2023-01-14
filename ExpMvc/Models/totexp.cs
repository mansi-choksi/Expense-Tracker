using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpMvc.Models
{
    public class totexp
    {
        [DisplayName("Total Expance Id")]
        public int id { get; set; }

        [Required, DisplayName("Total Expance")]
        public Nullable<int> totexp1 { get; set; }
    }
}
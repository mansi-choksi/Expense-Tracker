using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpMvc.Models
{
    public class exp
    {
        [DisplayName("Id")]
        public int id { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Title"), DisplayName("Title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Description"), DisplayName("Description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Category"), DisplayName("Description")]
        public string category { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Amount"), DisplayName("Amount")]
        public Nullable<int> amount { get; set; }
        [Required(ErrorMessage = "Please Enter Category Id"), DisplayName("Category Id")]
        public Nullable<int> catid { get; set; }
        private Nullable<System.DateTimeOffset> dt = DateTimeOffset.Now;
        [Required(ErrorMessage = "Please Enter Date Time"), DisplayName("Date Time Added")]
        public Nullable<System.DateTimeOffset> datetime { get { return dt; } set { dt = value; } }
       
        public virtual cat cat { get; set; }
    }
}
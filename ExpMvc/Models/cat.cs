using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpMvc.Models
{
    public class cat
    {
        public cat()
        {
            this.exps = new HashSet<exp>();
        }
        [DisplayName("Category Id")]
        public int id { get; set; }
        [Required(ErrorMessage = "Please Enter Category Name"), DisplayName("Category Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please Enter Categroy Expance Limit"), DisplayName("Category Expance Limite")]
        public Nullable<int> explim { get; set; }

        public virtual ICollection<exp> exps { get; set; }
    }
}
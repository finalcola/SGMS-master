using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Models
{
    public class Box
    {
        [Display(Name = "爱好")]
        public IEnumerable<SelectListItem> Hobbies { get; set; }
    }
}
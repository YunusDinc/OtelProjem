using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOtel.Models
{
    public class GaleriM
    {
        [Key]

        public int GaleriMID    { get; set; }

        public string Baslik   { get; set; }

        public string ResimURL { get; set; }
    }
}
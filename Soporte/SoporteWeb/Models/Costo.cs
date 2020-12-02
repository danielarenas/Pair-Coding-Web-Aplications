﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoporteWeb.Models
{
    public class Costo
    {
        public int Id { get; set; }
       [Display(Name ="Usuario")]
        public ApplicationUser User{ get; set; }
        [Display(Name ="Fecha")]
        public DateTime DateTime { get; set; }
        [Display (Name ="Descripcion")]
        public string Description { get; set; }
        [Display (Name ="Tipo")]
        public int TipoId { get; set; }
        [ForeignKey("TipoId")]
        public Tipo Tipo { get; set; }
    }
}
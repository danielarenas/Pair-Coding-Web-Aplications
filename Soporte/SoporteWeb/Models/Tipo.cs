
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoporteWeb.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name="Tipo")]
        public string Name { get; set; }
        public ICollection<Costo> Costos { get; set; }
    }
}
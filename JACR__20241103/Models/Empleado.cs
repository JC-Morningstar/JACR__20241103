using System;
using System.Collections.Generic;

namespace JACR__20241103.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            ReferenciasPersonales = new HashSet<ReferenciasPersonale>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Edad { get; set; }
        public string? Departamento { get; set; }
        public decimal? Salario { get; set; }

        public virtual ICollection<ReferenciasPersonale> ReferenciasPersonales { get; set; }
    }
}

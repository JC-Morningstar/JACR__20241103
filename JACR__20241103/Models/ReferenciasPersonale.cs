using System;
using System.Collections.Generic;

namespace JACR__20241103.Models
{
    public partial class ReferenciasPersonale
    {
        public int Id { get; set; }
        public int? EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }

        public virtual Empleado? Empleado { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTallerMecanico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.OrdenServicios = new HashSet<OrdenServicio>();
        }
    
        public Nullable<int> Ci { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FechaNac { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public Nullable<int> Telefono { get; set; }
        public int clienteID { get; set; }
    
        public virtual ICollection<OrdenServicio> OrdenServicios { get; set; }
    }
}

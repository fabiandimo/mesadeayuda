//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MesaAyuda.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solicitudes
    {
        public int Id { get; set; }
        public int IncidenciaId { get; set; }
        public int GradoId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Comentario { get; set; }
        public int Estado { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Grados Grados { get; set; }
        public virtual Incidencias Incidencias { get; set; }
    }
}
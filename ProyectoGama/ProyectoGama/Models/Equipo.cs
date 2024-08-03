using System;
using System.Collections.Generic;

namespace ProyectoGama.Models;

public partial class Equipo
{
    public int IdequipoFutbol { get; set; }

    public string NombreEquipo { get; set; } = null!;

    public string? Entrenador { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}

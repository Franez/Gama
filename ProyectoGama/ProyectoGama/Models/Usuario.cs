using System;
using System.Collections.Generic;

namespace ProyectoGama.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public int? Edad { get; set; }

    public int Posicion { get; set; }

    public int? EquipoActual { get; set; }

    public string? HistorialEquipos { get; set; }

    public string? Estadisticas { get; set; }

    public string? Nacionalidad { get; set; }

    public byte[]? FotoUsuario { get; set; }

    public string? Biografia { get; set; }

    public virtual Equipo? EquipoActualNavigation { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace EVManager.Api.Dtos
{
    public class CreatePuntoCargaDto
    {
        [Required(ErrorMessage = "La ubicación es obligatoria")]
        [StringLength(100, ErrorMessage = "La ubicación no puede tener más de 100 caracteres")]
        public string Ubicacion { get; set; }

        public bool EstaDisponible { get; set; }

        [Range(1, 1000, ErrorMessage = "La capacidad debe estar entre 1 y 1000 kW")]
        public int Capacidad { get; set; }
    }
}
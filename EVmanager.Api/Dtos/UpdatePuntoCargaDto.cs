using System.ComponentModel.DataAnnotations;

namespace EVManager.Api.Dtos
{
    public class UpdatePuntoCargaDto
    {
        public bool EstaDisponible { get; set; }

        [Range(1, 1000, ErrorMessage = "La capacidad debe estar entre 1 y 1000 kW")]
        public int Capacidad { get; set; }
    }
}
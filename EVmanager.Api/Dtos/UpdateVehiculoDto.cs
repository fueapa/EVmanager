using System.ComponentModel.DataAnnotations;

namespace EVManager.Api.Dtos
{
    public class UpdateVehiculoDto
    {
        [Range(0, 100, ErrorMessage = "El nivel de batería debe estar entre 0 y 100")]
        public int NivelBateria { get; set; }

        public bool EstaCargando { get; set; }
    }
}
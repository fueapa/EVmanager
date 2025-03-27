using System.ComponentModel.DataAnnotations;

namespace EVManager.Api.Dtos
{
    public class CreateVehiculoDto
    {
        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(10, ErrorMessage = "La placa no puede tener más de 10 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [StringLength(50, ErrorMessage = "El modelo no puede tener más de 50 caracteres")]
        public string Modelo { get; set; }

        [Range(0, 100, ErrorMessage = "El nivel de batería debe estar entre 0 y 100")]
        public int NivelBateria { get; set; }

        public bool EstaCargando { get; set; }
    }
}
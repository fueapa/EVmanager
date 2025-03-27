namespace EVManager.Domain
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int NivelBateria { get; set; }
        public bool EstaCargando { get; set; }
    }
}
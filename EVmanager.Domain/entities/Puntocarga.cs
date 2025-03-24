namespace EVManager.Domain
{
    public class PuntoCarga
    {
        public int Id { get; set; }          
        public string Ubicacion { get; set; } 
        public bool EstaDisponible { get; set; } 
        public int Capacidad { get; set; }     
    }
}
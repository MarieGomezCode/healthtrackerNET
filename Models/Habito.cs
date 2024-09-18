namespace healthtracker.interfaces
{
    public class Habito
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreadoEn { get; set; }
        public Usuario Usuario { get; set; }
    }
}

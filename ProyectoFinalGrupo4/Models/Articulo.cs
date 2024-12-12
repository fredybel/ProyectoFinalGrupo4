
using SQLite;

namespace ProyectoFinalGrupo4.Models
{
    public class Articulo
    {
        [PrimaryKey, AutoIncrement]
        public string NombreArticulo { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Valor { get; set; }

        [PrimaryKey,  AutoIncrement]
        public int Cantidad { get; set; }
    }
}

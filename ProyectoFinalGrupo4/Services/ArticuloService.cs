using SQLite;
using ProyectoFinalGrupo4.Models;

namespace ProyectoFinalGrupo4.Services
{
    public class ArticuloService
    {
        private readonly SQLiteConnection SQLiteConnection;

        public ArticuloService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Articulo.db3");
            SQLiteConnection = new SQLiteConnection(dbPath);
            SQLiteConnection.CreateTable<Articulo>();

            Articulo articulo = new Articulo();
            articulo.NombreArticulo = "Articulo";
            articulo.Valor = 0;
            articulo.Cantidad = 0;
            Insert(articulo);
        }

        public List<Articulo> GetAll()
        {
            var res = SQLiteConnection.Table<Articulo>().ToList();
            return res;
        }

        public int Insert(Articulo articulo)
        {
            return SQLiteConnection.Insert(articulo);
        }

        public int Update(Articulo articulo)
        {
            return SQLiteConnection.Update(articulo);
        }

        public int Delete(Articulo articulo)
        {
            return SQLiteConnection.Delete(articulo);
        }

    }
}

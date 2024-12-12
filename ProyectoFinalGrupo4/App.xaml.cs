using ProyectoFinalGrupo4.Services;
using ProyectoFinalGrupo4.Views;

namespace ProyectoFinalGrupo4;

public partial class App : Application
{
    public static DatabaseService DatabaseService { get; private set; }

    public App()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db3");
        DatabaseService = new DatabaseService(dbPath);

        MainPage = new NavigationPage(new MainPage(DatabaseService));
    }
}
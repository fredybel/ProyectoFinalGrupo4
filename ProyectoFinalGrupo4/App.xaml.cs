using ProyectoFinalGrupo4.Views;

namespace ProyectoFinalGrupo4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainEmpleadoView());
        }
    }
}
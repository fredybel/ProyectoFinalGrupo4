using ProyectoFinalGrupo4.Services;
using ProyectoFinalGrupo4.ViewModels;
using ProyectoFinalGrupo4.Converters;

namespace ProyectoFinalGrupo4.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly TasksViewModel _viewModel;

        public MainPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _viewModel = new TasksViewModel(databaseService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadTasksCommand.ExecuteAsync(null);
        }
    }
}
using ProyectoFinalGrupo4.Models;
using ProyectoFinalGrupo4.Services;
using ProyectoFinalGrupo4.ViewModels;
using System.Diagnostics;

namespace ProyectoFinalGrupo4.Views
{
    public partial class AddEditTaskPage : ContentPage
    {
        private readonly TaskItem _task;
        private readonly DatabaseService _databaseService;
        private readonly TasksViewModel _tasksViewModel;

        public AddEditTaskPage(TaskItem task, DatabaseService databaseService, TasksViewModel tasksViewModel)
        {
            InitializeComponent();
            _task = task;
            _databaseService = databaseService;
            _tasksViewModel = tasksViewModel;
            BindingContext = _task;


            Title = task.Id == 0 ? "Agregar Nueva Tarea" : "Editar Tarea";
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {

                Debug.WriteLine($"Saving task - ID: {_task.Id}, Title: {_task.Title}, Status: {_task.Status}");

                await _databaseService.SaveTaskAsync(_task);
                _tasksViewModel.UpdateTask(_task);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", $"No se pudo guardar la tarea: {ex.Message}", "OK");
                Debug.WriteLine($"Error saving task: {ex}");
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
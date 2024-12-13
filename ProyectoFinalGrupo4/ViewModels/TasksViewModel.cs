using System.Collections.ObjectModel;
using ProyectoFinalGrupo4.Models;
using ProyectoFinalGrupo4.Services;
using ProyectoFinalGrupo4.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProyectoFinalGrupo4.ViewModels
{
    public partial class TasksViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private ObservableCollection<TaskItem> _tasks;

        [ObservableProperty]
        private ObservableCollection<TaskItem> _selectedTasks = new ObservableCollection<TaskItem>();

        public TasksViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            Tasks = new ObservableCollection<TaskItem>();
        }

        [RelayCommand]
        private async Task LoadTasks()
        {
            var tasks = await _databaseService.GetTasksAsync();
            Tasks.Clear();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        [RelayCommand]
        private async Task AddTask()
        {
            var newTask = new TaskItem { Status = TaskItemStatus.PorHacer };
            var page = new AddEditTaskPage(newTask, _databaseService, this);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        [RelayCommand]
        private async Task EditTask(TaskItem task)
        {
            var page = new AddEditTaskPage(task, _databaseService, this);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        [RelayCommand]
        private async Task DeleteTask(TaskItem task)
        {
            await _databaseService.DeleteTaskAsync(task);
            Tasks.Remove(task);

        }

        [RelayCommand]
        private async Task DeleteSelectedTasks()
        {
            if (SelectedTasks.Any())
            {
                await _databaseService.DeleteMultipleTasksAsync(SelectedTasks.ToList());
                foreach (var task in SelectedTasks.ToList())
                {
                    Tasks.Remove(task);
                }
                SelectedTasks.Clear();
            }
        }

        public async Task UpdateTask(TaskItem task)
        {
            await _databaseService.SaveTaskAsync(task);
            var existingTask = Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                var index = Tasks.IndexOf(existingTask);
                Tasks[index] = task;
            }
            else
            {
                Tasks.Add(task);
            }
        }
    }
}
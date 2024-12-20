﻿using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProyectoFinalGrupo4.Models
{
    public enum TaskItemStatus
    {
        PorHacer,
        EnProceso,
        Finalizada
    }

    [Table("Tasks")]
    public partial class TaskItem : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private TaskItemStatus _status;

        [ObservableProperty]
        private DateTime _createdDate;

        public int StatusIndex
        {
            get => (int)_status;
            set => _status = (TaskItemStatus)value;
        }
    }
}

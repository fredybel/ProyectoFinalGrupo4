using SQLite;
using ProyectoFinalGrupo4.Models;
using System.Diagnostics;

namespace ProyectoFinalGrupo4.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TaskItem>().Wait();
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _database.Table<TaskItem>().ToListAsync();
        }

        public async Task<TaskItem> GetTaskAsync(int id)
        {
            return await _database.Table<TaskItem>()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveTaskAsync(TaskItem task)
        {
            try
            {
                if (task.Id != 0)
                {

                    Debug.WriteLine($"Updating task: {task.Id}, Title: {task.Title}, Status: {task.Status}");
                    return await _database.UpdateAsync(task);
                }
                else
                {

                    task.CreatedDate = DateTime.Now;
                    Debug.WriteLine($"Inserting new task, Title: {task.Title}, Status: {task.Status}");
                    return await _database.InsertAsync(task);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in SaveTaskAsync: {ex}");
                throw;
            }
        }

        public async Task<int> DeleteTaskAsync(TaskItem task)
        {
            return await _database.DeleteAsync(task);
        }

        public async Task DeleteMultipleTasksAsync(List<TaskItem> tasks)
        {
            foreach (var task in tasks)
            {
                await _database.DeleteAsync(task);
            }
        }
    }
}

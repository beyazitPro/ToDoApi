using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.models
{
    public class ToDoItem
    {
        [Required]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool isCompleted { get; set; }
    }
}

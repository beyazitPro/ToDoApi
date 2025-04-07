using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppEntities
{
    public class TodoItem
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(50)]
        public string title { get; set; }
        [StringLength(100)]
        public string description { get; set; }
        [Required]
        public bool isCompleted { get; set; }
    }
}

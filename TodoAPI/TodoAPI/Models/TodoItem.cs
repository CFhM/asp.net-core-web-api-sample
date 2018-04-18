using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        [Key, Required]
        public int tipId { get; set; }
        public int userId { get; set; }
        public string content { get; set; }
        public DateTime createTime { get; set; }
    }
}

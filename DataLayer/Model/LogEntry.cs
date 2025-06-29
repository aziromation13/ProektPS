using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class LogEntry
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}

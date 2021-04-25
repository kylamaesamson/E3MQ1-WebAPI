using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO_API.Models
{
    public class Todo
    {
        public double ID { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}

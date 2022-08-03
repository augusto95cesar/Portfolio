using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IterUpApi.Model.WorkFlow
{
    public class WorkFlow
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public int UserId { get; set; } 
    }
}

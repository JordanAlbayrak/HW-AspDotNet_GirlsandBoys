using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Models.Task
{
    public interface ITaskService
    {
       List<Tasks> GetTasks();
    }
}

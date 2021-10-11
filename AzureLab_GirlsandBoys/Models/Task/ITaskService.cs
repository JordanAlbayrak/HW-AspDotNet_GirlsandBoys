using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Models.Task
{
    //Creating a GetTasks() method
    public interface ITaskService
    {
       List<Tasks> GetTasks();
    }
}

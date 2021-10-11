using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Models.Task
{
    public class TeacherTaskService : ITaskService
    {
        //Adds didferent object instantions to a list called taskList, which will be returned upon calling GetTaks()
        public List<Tasks> GetTasks()
        {
            Tasks t1 = new Tasks("100A10", "Grading Scripts", "F-251");
            Tasks t2 = new Tasks("100A11", "Teaching the class", "F-249");
            Tasks t3 = new Tasks("100A12", "Consulting with students", "F-251");
            Tasks t4 = new Tasks("100A13", "Having a meeting with admin", "F-199");

            List<Tasks> taskList = new List<Tasks>() { t1, t2, t3, t4 };

            return taskList;
        }
    }
}

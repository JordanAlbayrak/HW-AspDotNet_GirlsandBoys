using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Models.Task
{
    public class StudentTaskService : ITaskService
    {
        //Adds didferent object instantions to a list called taskList, which will be returned upon calling GetTaks()
        public List<Tasks> GetTasks()
        {
            Tasks t1 = new Tasks("200B10", "Attend classes", "F-249");
            Tasks t2 = new Tasks("200B11", "Do some tutoring", "A-103");
            Tasks t3 = new Tasks("200B12", "Make some friends", "College");
            Tasks t4 = new Tasks("200B13", "Score good grades", "Departement");

            List<Tasks> taskList = new List<Tasks>() { t1, t2, t3, t4 };

            return taskList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Models
{
    [Table("StudentTask")]
    public class StudentTask
    {
        [Key]
        public int ID { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}

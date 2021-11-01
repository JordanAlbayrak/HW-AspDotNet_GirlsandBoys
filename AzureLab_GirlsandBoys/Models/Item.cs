using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureLab_GirlsandBoys.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        private int id { get; set; }
        private string model { get; set; }
        private string company { get; set; }
        private string released { get; set; }
        private string country { get; set; }
    }
}

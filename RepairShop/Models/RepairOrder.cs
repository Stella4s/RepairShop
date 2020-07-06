using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class RepairOrder
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }

        [DisplayName("Begin Datum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DisplayName("Eind Datum")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public RepairStatus RepairStatus { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

        public Technician Technician { get; set; }
        public int? HoursWorkedOn { get; set; }
        public string Description { get; set; }
    }

    public enum RepairStatus
    {
        Awaiting,
        InProgress,
        AwaitingParts,
        Finished
    }
}
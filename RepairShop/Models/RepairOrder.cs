using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    /*public class DateFromNowAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= (DateTime.Today); //Dates Greater than or equal to today are valid (true)

        }
    }*/

    public class RepairOrder
    {
        public int ID { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayName("Begin Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DateFromNow]
        public DateTime StartDate { get; set; }
        [DisplayName("Eind Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public RepairStatus RepairStatus { get; set; }
        public virtual ICollection<StockPart> Parts { get; set; }

        public virtual Technician Technician { get; set; }
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
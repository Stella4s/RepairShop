﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class DateFromNowAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= (DateTime.Today); //Dates Greater than or equal to today are valid (true)

        }
    }
    public class RepairOrder
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }

        [DisplayName("Begin Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DateFromNow]
        public DateTime StartDate { get; set; }
        [DisplayName("Eind Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public RepairStatus RepairStatus { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

        public Technician Technician { get; set; }
        public int? HoursWorkedOn { get; set; }
        public string Description { get; set; }

        public bool IsLate { get; set; }

        /// <summary>
        /// To use to check for a certain condition and either put in IsLate or check in html to get a return value.
        /// </summary>
        /// <returns></returns>
        public bool CheckIsLate()
        {
            if (!IsValidTime(StartDate) && RepairStatus == RepairStatus.Awaiting)
                return true;
            else
                return false;
        }
        /// <summary>
        /// For checking if a StartTime is correct compared to the current time.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsValidTime(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Today; //Dates Greater than or equal to today are valid (true)

        }
    }

    public enum RepairStatus
    {
        Awaiting,
        InProgress,
        AwaitingParts,
        Finished
    }
}
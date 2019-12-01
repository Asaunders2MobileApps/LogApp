using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LogApp
{
    public class LogItem 
    {
        #region Variables
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime LogDate { get; set; }
        public double OdometerMileage { get; set; }
        public double PricePerGallon { get; set; }
        #endregion

        #region MinDate (DateTime)
        //set minimum date to three years from todays date
        private DateTime _MinDate = DateTime.Now.AddYears(-3);
        public DateTime MinDate
        {
            get
            {
                if (_MinDate == null) MinDate = DateTime.Now;
                return _MinDate;
            }
            set
            {
                if (_MinDate == value) return;
                _MinDate = value;
            }
        }
        #endregion MinDate  (DateTime)

        #region MaxDate (DateTime)
        private DateTime _MaxDate = DateTime.Now;
        public DateTime MaxDate
        {
            get
            {
                if (_MaxDate == null) MaxDate = DateTime.Now;
                return _MaxDate;
            }
            set
            {
                if (_MaxDate == value) return;
                _MaxDate = value;
            }
        }
        #endregion MaxDate  (DateTime)
        
    }
}

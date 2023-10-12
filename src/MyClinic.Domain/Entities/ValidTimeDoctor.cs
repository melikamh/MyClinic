using MyClinic.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// زمان های معتبر پزشک بر اساس زمان کلینیک برای رزرو 
    /// </summary>
    public class ValidTimeDoctor : Entity
    {
        private readonly List<Appointment> _appointment = new();

        public ValidTimeDoctor()
        {
        }

        private ValidTimeDoctor(int id, Doctor doctor, ValidTime validTime, TimeSpan startTime, TimeSpan endTime) : base(id)
        {
            DoctorId = doctor.Id;
            ValidTimeId = validTime.Id;
            StartTime=startTime; 
            EndTime=endTime;
        }

        /// <summary>
        /// شناسه پزشک
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// شناسه موجودیت ValidTime
        /// </summary>
        public int ValidTimeId { get; set; }

        /// <summary>
        /// شروع زمان ویزیت
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// پایان زمان ویزیت
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// تاریخ ویزیت
        /// </summary>
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public IReadOnlyCollection<Appointment> Appointment => _appointment;

    }
}

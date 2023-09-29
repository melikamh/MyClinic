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
        /// موجودیت پزشک
        /// </summary>
        public Doctor Doctor { get; set; }

        /// <summary>
        /// موجودیت زمانهای معتبر
        /// </summary>
        public ValidTime ValidTime { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}

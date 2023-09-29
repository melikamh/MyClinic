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
    public class ValidTimeDoctor
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
    }
}

using MyClinic.Domain.Enums;
using MyClinic.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// زمانهای معتبر کلینیک برای رزور
    /// </summary>
    public class ValidTime : Entity
    {
        private ValidTime(int id, DaysOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime) : base(id)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// روزهای هفته
        /// </summary>
        public DaysOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// زمان شروع مجاز
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// زمان اتمام پایان رزرو
        /// </summary>
        public TimeSpan EndTime { get; set; }

    }
}

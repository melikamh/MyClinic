using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyClinic.Domain.Enums
{
    /// <summary>
    /// روز های هفته 
    /// </summary>
    public enum DaysOfWeek
    {
        [Display(Name = "یکشنبه")]
        Sunday = 0,

        [Display(Name = "دوشنبه")]
        Monday,

        [Display(Name = "سه شنبه")]
        Tuesday,

        [Display(Name = "چهارشنبه")]
        Wednesday,

        [Display(Name = "پنج شنبه")]
        Thursday,

        [Display(Name = "جمعه")]
        Friday,

        [Display(Name = "شنبه")]
        Saturday


    }
}

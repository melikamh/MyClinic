using MyClinic.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// اطلاع رسانی
    /// </summary>
    // TODO: Part B
    public class Notification: Entity
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}

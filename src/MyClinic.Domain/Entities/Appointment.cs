using MyClinic.Domain.Primitives;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// وقت ملاقات پزشک و بیمار
    /// </summary>
    public class Appointment: AggregateRoot
    {
        /// <summary>
        /// رفرنس به موجودیت ValidTimeDoctor
        /// </summary>
        public int ValidTimeDoctorId { get; set; }

        /// <summary>
        /// شناسه بیمار
        /// </summary>
        public int PatientID { get; set; }
    }
}
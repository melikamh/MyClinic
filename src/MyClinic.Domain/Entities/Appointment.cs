using MyClinic.Domain.Primitives;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// وقت ملاقات پزشک و بیمار
    /// </summary>
    public class Appointment : Entity
    {
        private readonly List<ValidTimeDoctor> _validTimeDoctors = new();

        private Appointment(int id, ValidTimeDoctor validTimeDoctor, Patient patient) : base(id)
        {
            ValidTimeDoctorId = validTimeDoctor.Id;
            PatientID = patient.Id;
        }

        private Appointment()
        { }
        /// <summary>
        /// رفرنس به موجودیت ValidTimeDoctor
        /// </summary>
        public int ValidTimeDoctorId { get; set; }

        /// <summary>
        /// شناسه بیمار
        /// </summary>
        public int PatientID { get; set; }
        public IReadOnlyCollection<ValidTimeDoctor> ValidTimeDoctors => _validTimeDoctors;

    }
}
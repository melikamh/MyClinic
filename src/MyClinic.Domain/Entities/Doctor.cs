using MyClinic.Domain.Enums;
using MyClinic.Domain.Primitives;
using MyClinic.Domain.ValueObjects;

namespace MyClinic.Domain.Entities
{
    public class Doctor : AggregateRoot
    {
        /// <summary>
        /// نام
        /// </summary>
        public FirstName FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public LastName LastName { get; set; }

        /// <summary>
        /// دکتر دارای تخصص
        /// </summary>
        public DoctorType Specialization { get; set; }

        public ICollection<ValidTimeDoctor> ValidTimeDoctor { get; set; }


    }
}

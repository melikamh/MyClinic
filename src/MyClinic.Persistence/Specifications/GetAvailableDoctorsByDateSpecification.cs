using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Persistence.Specifications
{
    internal class GetAvailableDoctorsByDateSpecification : Specification<ValidTimeDoctor>
    {
        public GetAvailableDoctorsByDateSpecification(int doctorId, DateTime date)
           : base(validTimeDoctor => validTimeDoctor.Date.Date == date.Date &&
                               validTimeDoctor.DoctorId == doctorId)
        {
            AddInclude(validTime => validTime.Doctor);
            
        }
    }
}

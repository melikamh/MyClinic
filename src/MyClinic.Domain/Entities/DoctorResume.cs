using MyClinic.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// رزومه پزشک
    /// </summary>
    // TODO: Part B
    public class DoctorResume : Entity
    {
        public int DoctorId { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
    }
}

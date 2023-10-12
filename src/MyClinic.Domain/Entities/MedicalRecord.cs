using MyClinic.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Entities
{
    /// <summary>
    /// ویزیتهای یک پزشک
    /// </summary>
    // TODO: Part B
    public class MedicalRecord:Entity
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}

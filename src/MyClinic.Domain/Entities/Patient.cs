﻿using MyClinic.Domain.Primitives;
using MyClinic.Domain.ValueObjects;

namespace MyClinic.Domain.Entities
{
    public class Patient :Entity
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
        /// کد ملی بیمار
        /// </summary>

        public NationalCode NationalCode { get; set; }

        /// <summary>
        /// قرار ملاقاتهای دکتر
        /// </summary>
        public List<Appointment> Appointments { get; set; }
    }
}

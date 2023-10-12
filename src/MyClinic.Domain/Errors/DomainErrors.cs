using MyClinic.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Errors
{
    public static class DomainErrors
    {
        
        public static class NationalCode
        {
            public static readonly Error Empty = new(
                "NationalCode.Empty",
                "لطفا کد ملی را صحیح وارد نمایید");

            public static readonly Error InvalidFormat = new(
                "NationalCode.InvalidFormat",
                "این کد ملی اشتباه است ");
        }

        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "نام را وارد کنید");

            public static readonly Error TooLong = new(
                "FirstName.TooLong",
                "نام وارد شده معتبر نیست .");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "نام خانوادگی را وارد کنید");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "نام خانوادگی وارد شده معتبر نیست.");
        }

        public static class ValidTimeDoctor
        {
            public static readonly Func<string, Error> NotFound = date => new Error(
                    "ValidTimeDoctor.NotFound",
                    $"پزشک مورد نظر شما در تاریخ {date}  هیچ نوبتی ندارد.");
        }

        public static class ValidAppointment
        {
            public static readonly Func<string, Error> NotFound = date => new Error(
                    "ValidAppointment.Notallowed",
                    $"تعداد مجاز نوبت در تاریخ {date} به پایان رسیده است.");
        }
    }
}

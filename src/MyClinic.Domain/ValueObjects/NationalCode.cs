using MyClinic.Domain.Errors;
using MyClinic.Domain.Primitives;
using MyClinic.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyClinic.Domain.ValueObjects
{
    public sealed class NationalCode : ValueObject
    {
        private NationalCode(string value) => Value = value;
        public string Value { get; }
        public static Result<NationalCode> Create(string nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد
            if (string.IsNullOrWhiteSpace(nationalCode))
            {
                return Result.Failure<NationalCode>(DomainErrors.NationalCode.Empty);
            }

            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                return Result.Failure<NationalCode>(DomainErrors.NationalCode.Empty);

            int parsedResult;
            // بررسی مقدار عددی 
            if (int.TryParse(nationalCode, out parsedResult))
            {
                // بررسی یکسان بودن اعداد
                var allDigitEqual = new[] { "0000000000", "1111111111",
                                            "2222222222", "3333333333",
                                            "4444444444", "5555555555",
                                            "6666666666", "7777777777",
                                            "8888888888", "9999999999" };
                if (allDigitEqual.Contains(nationalCode))
                    return Result.Failure<NationalCode>(DomainErrors.NationalCode.Empty);
                // بررسی فرمت کد ملی
                var check = Convert.ToInt32(nationalCode.Substring(9, 1));
                var sum = Enumerable.Range(0, 9)
                    .Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
                    .Sum() % 11;
                if (sum < 2 ? check == sum : check + sum == 11)
                    new NationalCode(nationalCode);
            }

            return Result.Failure<NationalCode>(DomainErrors.NationalCode.InvalidFormat);

        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}

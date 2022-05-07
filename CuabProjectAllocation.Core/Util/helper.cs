using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CuabProjectAllocation.Core.Util
{
    public static class helper
    {
        public static string ResolveFlValidationErrorToStr(List<ValidationFailure> validationResult)
        {
            string result = "";

            if (validationResult.Any())
            {
                result = string.Join(',', validationResult);
            }

            return result;
        }

        public static List<string> SplitCsv(this string csvList, bool nullOrWhiteSpaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhiteSpaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(x => x.Trim())
                .ToList();
        }

        public static long GenerateRadomNumber()
        {
            var bytes = new byte[sizeof(Int64)];
            RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
            Gen.GetBytes(bytes);

            long random = BitConverter.ToInt64(bytes, 0);

            //Remove any possible negative generator numbers and shorten the generated number to 12-digits
            string pos = random.ToString().Replace("-", "").Substring(0, 12);

            return Convert.ToInt64(pos);
        }

        public static string GenerateRandomNumberV2(int size)
        {
            using(var crypto = new RNGCryptoServiceProvider())
            {
                var bits = (size * 6);
                var byte_size = ((bits + 7) / 8);
                var byteArray = new byte[byte_size];
                crypto.GetBytes(byteArray);

                return Convert.ToBase64String(byteArray);
            }
        }
    }
}

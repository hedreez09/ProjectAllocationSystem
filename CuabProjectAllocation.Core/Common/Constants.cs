using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Common
{
    public static class Constants
    {
        public static string Successful { get; } = "00";
        public static string ResetPassword { get; } = "10";
        public static string InputValidationError { get; } = "12";
        public static string ErrorOccured { get; } = "97";
        public static string SomethingWentWrong { get; } = "99";
    }
}

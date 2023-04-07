using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingSystem.Business
{
    public class CommandResult
    {
        private static string DefaultFailureMessage = "İşlem Başarısız";
        private static string DefaultSuccessMessage = "İşlem Başarılı";

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public string ErrorMessage { get; private set; }

        internal static CommandResult Error(Exception ex)
        {
            return Error(DefaultFailureMessage, ex);
        }

        internal static CommandResult Error(string message, Exception ex)
        {
            return new CommandResult
            {
                IsSuccess = false,
                Message = message,
                ErrorMessage = ex.ToString()
            };
        }
        public static CommandResult Failure()
        {
            return CommandResult.Failure(DefaultFailureMessage);
        }
        public static CommandResult Failure(string message)
        {
            return new CommandResult
            {
                IsSuccess = false,
                Message = message
            };
        }
        internal static CommandResult Success(string message)
        {
            return new CommandResult
            {
                IsSuccess = true,
                Message = message,
                ErrorMessage = string.Empty
            };
        }
        public static CommandResult Success()
        {
            return Success(DefaultSuccessMessage);
        }

    }
}

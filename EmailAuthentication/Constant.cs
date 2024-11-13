using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailAuthentication
{
    public static class Constant
    {
        public static readonly string STATUS_EMAIL_OK = "The OTP number was sent successfully. Please check your email.";
        public static readonly string STATUS_EMAIL_FAIL = "Email address does not exist or sending to the email has failed.";
        public static readonly string STATUS_EMAIL_INVALID = "Email address is invalid.";

        public static readonly string STATUS_OTP_OK = "OTP is valid and checked!";
        public static readonly string STATUS_OTP_Invalid = "The OTP does not match.Please enter the correct number.";
        public static readonly string STATUS_OTP_TIMEOUT = "Email address is invalid.";
        public static readonly string STATUS_OTP_MAXATTEMPT = "You have reached the maximum number attempts. Please re-generate a new OTP number and try again later.";

        public static readonly int MaxAttempts = 10; // Maximum allowed attempts
    }
}
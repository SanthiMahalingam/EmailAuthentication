using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace EmailAuthentication
{
    public class OTPService
    {
        private static readonly Random _random = new Random();
        private const int OtpLength = 6;
        private static readonly TimeSpan OtpExpiryDuration = TimeSpan.FromMinutes(1);  // OTP valid for 1 minutes

        // Method to generate a random OTP
        public static string GenerateOtp(out DateTime expiryTime)
        {
            string otp = _random.Next(100000, 999999).ToString(); // 6-digit OTP
            expiryTime = DateTime.Now.Add(OtpExpiryDuration);    // OTP expiration time
            return otp;
        }

        // Method to send OTP email
        public static int SendOtpEmail(string email, string otp)
        {
           
            try
            {
                if (IsValidEmail(email))
                {
                    var fromAddress = new MailAddress("Test@gmail.com","Mail"); // Sender's email address
                    var toAddress = new MailAddress(email); // Recipient's email address
                    const string fromPassword = ""; // Use app password if 2FA is enabled
                    const string subject = "Your OTP Code";
                    string body = $"Your OTP code is: {otp}. The code is valid for 1 minute.";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com", // Gmail SMTP server
                        Port = 587, // Use port 587 for TLS
                        EnableSsl = true, // Enable SSL/TLS
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword), // Credentials for SMTP
                        Timeout = 100000 // Timeout in milliseconds
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        try
                        {
                            smtp.Send(message); // Send the email
                            Console.WriteLine("Email sent successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to send email: " + ex.Message); // Handle errors
                        }
                    }
                    return (int)EmailStatus.STATUS_EMAIL_OK;
                }
                else
                {
                    return (int) EmailStatus.STATUS_EMAIL_INVALID;
                }

            }
            catch(Exception ex)
            {
                return (int)EmailStatus.STATUS_EMAIL_FAIL;
            }

        }
        // Method to validate E-mail address
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        // Method to check if OTP is expired
        public static bool IsOtpExpired(DateTime otpExpiryTime)
        {
            return DateTime.Now > otpExpiryTime;  // Check if the current time is past the expiry time
        }
    }

 public   enum EmailStatus
    {
        STATUS_EMAIL_OK = 1,
        STATUS_EMAIL_FAIL = 2,
        STATUS_EMAIL_INVALID = 3
    }

    public enum OTPStatus
    {
        STATUS_OTP_OK = 1,
        STATUS_OTP_FAIL = 2,
        STATUS_OTP_TIMEOUT = 3
    }

}
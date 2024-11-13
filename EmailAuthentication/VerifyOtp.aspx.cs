using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailAuthentication
{
    public partial class VerifyOtp : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize attempts on first load
                Session["LoginAttempts"] = 0;
            }
        }

        protected void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            try
            {
                string userOtp = txtOtp.Text;
                string sessionOtp = Session["OTP"]?.ToString();
                DateTime otpExpiryTime = (DateTime?)Session["OTPExpiryTime"] ?? DateTime.MinValue;
                int attemptCount = (int)Session["LoginAttempts"];

                // Check if OTP has expired
                if (OTPService.IsOtpExpired(otpExpiryTime))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "OTP has expired. Please request a new one.";
                }
                else if (userOtp == sessionOtp)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "OTP verified successfully!. You will be redirected shortly.";
                    Session["LoginAttempts"] = 0;
                    // Proceed with authenticated process
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('HomePage.aspx') }, 5000);", true);

                }
                else
                {
                    attemptCount++;
                    Session["LoginAttempts"] = attemptCount; // Update the attempt count in session
                    int attemptsLeft = Constant.MaxAttempts - attemptCount;

                    if (attemptsLeft > 0)
                    {
                        lblMessage.Text = $"Incorrect OTP. You have {attemptsLeft} attempt(s) left.";
                    }
                    else
                    {
                        lblMessage.Text = Constant.STATUS_OTP_MAXATTEMPT;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }


                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
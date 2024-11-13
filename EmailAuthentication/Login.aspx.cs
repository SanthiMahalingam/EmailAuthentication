using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmailAuthentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnSendOtp_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;

                // Generate OTP and get the expiration time
                DateTime otpExpiryTime;
                string otp = OTPService.GenerateOtp(out otpExpiryTime);

                // Store the OTP and expiry time in the session
                Session["OTP"] = otp;
                Session["OTPExpiryTime"] = otpExpiryTime;
                Session["Email"] = email;

                // Send OTP to the user's email
             int Emailstatus=   OTPService.SendOtpEmail(email, otp);

                if(Emailstatus == (int) EmailStatus.STATUS_EMAIL_OK)
                {
                    lblMessage.Text =  Constant.STATUS_EMAIL_OK + "\n Page will be redirected shortly to proceed further....";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    // Redirect to the OTP verification page
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('VerifyOtp.aspx') }, 5000);", true);
                }
                else if(Emailstatus == (int)EmailStatus.STATUS_EMAIL_INVALID)
                {
                    lblMessage.Text = Constant.STATUS_EMAIL_INVALID;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

                else if (Emailstatus == (int)EmailStatus.STATUS_EMAIL_FAIL)
                {
                    lblMessage.Text = Constant.STATUS_EMAIL_FAIL;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }



            }
            catch (Exception ex)
            { 

            }

        }
    }
}
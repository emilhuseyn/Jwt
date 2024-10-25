using App.Business.Services.ExternalServices.Interfaces;
using App.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.ExternalServices.Abstractions
{
    public class MailService : IMailService
    {
        public async Task SendSubscriptionService(string email)
        {
            
            var bodyHtmlScript = GenerateSubscriptionHtml();

            using (var client = new SmtpClient("********", 1000))
            {
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("********", "********");
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("********"),
                    Subject = "Account Unbanned",
                    Body = bodyHtmlScript,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);
                await client.SendMailAsync(mailMessage);
            }
        }

        public string GenerateSubscriptionHtml()
        {
            string request = $@"
            <!DOCTYPE html>
            <html lang='en'>
              <head>
                <meta charset='UTF-8' />
                <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                <title>Your Account is Unbanned</title>
              </head>
              <body style='font-family: DM Sans, Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; box-sizing: border-box;'>
                <table role='presentation' width='100%' cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                  <tr>
                    <td align='center'>
                      <table role='presentation' width='100%' cellspacing='0' cellpadding='0' border='0' style='background-color: #ffffff; border-radius: 12px; box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1); border: 1px solid #e0e0e0; max-width: 600px; width: 100%;'>
                        <tr>
                          <td align='center' style='background-color: #4CAF50; padding: 35px 0;'>
                            <img src='https://auth.apptech.edu.az/uploads/logo.png' alt='AppTech' width='200' style='display: block;'/>
                          </td>
                        </tr>
                        <tr>
                          <td style='padding: 42px 40px 0 40px; text-align: center; font-family: Space Grotesk, Arial, sans-serif; font-weight: 700;'>
                            <h1 style='margin: 0; font-size: 49px;'>Your account is unbanned!</h1>
                          </td>
                        </tr>
                        <tr>
                          <td style='padding: 40px; text-align: center; color: #333333;'>
                            <img src='https://auth.apptech.edu.az/uploads/illustration.png' alt='' style='max-width: 100%; display: block; margin: 0 auto;'/>
                            <p style='font-size: 23px; line-height: 1.8; margin: 20px 0;'>Dear ,</p>
                            <p style='font-size: 23px; line-height: 1.8; margin: 20px 0;'>Your account on the AppTech platform has been successfully unbanned. You now have full access to our platform again.</p>
                            <p style='font-size: 23px; line-height: 1.8; margin: 20px 0;'>Welcome back!</p>
                          </td>
                        </tr>
                        <tr>
                          <td style='text-align: center; background-color: #191b1e; color: #ffffff; font-size: 14px; font-family: DM Sans, Arial, sans-serif; font-weight: 400;'>
                            <h1 style='padding: 50px 10px 5px; font-size: 34px;'>Contact Us</h1>
                            <hr style='width: 380px; color: #ffffff; border: none; border-top: 1px solid #ffffff; margin: 0 auto;' />
                            <div style='margin: 20px 0;'>
                              <a href='https://www.instagram.com/apptech.edu.az/' target='_blank' style='display: inline-block; margin: 0 10px; color: #ffffff; text-decoration: none;'>
                                <img src='https://auth.apptech.edu.az/uploads/instagram.png' style='max-width: 100%; display: block; margin: 0 auto;'/>
                              </a>
                              <a href='https://www.linkedin.com/company/apptechmmc/' target='_blank' style='display: inline-block; margin: 0 10px; color: #ffffff; text-decoration: none;'>
                                <img src='https://auth.apptech.edu.az/uploads/linkedin.svg' style='max-width: 100%; display: block; margin: 0 auto;'/>
                              </a>
                              <a href='https://wa.me/0504044103' target='_blank' style='display: inline-block; margin: 0 10px; color: #ffffff; text-decoration: none;'>
                                <img src='https://auth.apptech.edu.az/uploads/whatsapp.png' style='max-width: 100%; display: block; margin: 0 auto;'/>
                              </a>
                            </div>
                            <div style='background-color: #4CAF50; color: #333333; padding: 10px; text-align: center;'>
                              <p style='margin: 0;'>Copyright © 2024 Apptech | All Rights Reserved</p>
                            </div>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </table>
              </body>
            </html>";
            return request;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMiaAutomatizacion.MailHandler
{
    public class SendMailHandler
    {
        public bool EnableSendMails { get; set; }
        public string[] Mails { get; set; } = new string[2];
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string SubjectValue { get; set; }

        private string HTMLMail;

        private static SendMailHandler _instance = null;
        private static readonly object padlock = new object();

        public static SendMailHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                            _instance = new SendMailHandler();
                    }
                }

                return _instance;
            }
        }

        private SendMailHandler()
        {
            EnableSendMails = true;
            Mails[0] = "rosamariaceraosorio@gmail.com";
            Mails[1] = "alfreql@gmail.com";
            MailAddress = "rosamariaceraosorio@gmail.com";
            Password = "elERRe*516";
            HTMLMail = "";
        }

        public void SendSummaryReportMail()
        {
            if (EnableSendMails)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(MailAddress, Password)
                };
                if (Mails != null && Mails.Length != 0 && !string.IsNullOrEmpty(HTMLMail))
                {
                    foreach (string m in Mails)
                    {
                        if (!string.IsNullOrEmpty(m))
                        {
                            using (var message = new MailMessage(MailAddress, m)
                            {
                                Subject = SubjectValue,
                                IsBodyHtml = true
                            })
                            {
                                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                 HTMLMail,
                                 null, "text/html");

                                message.AlternateViews.Add(htmlView);
                                smtp.Send(message);
                            }
                        }
                    }
                }
            }
        }

        public void SetData(int passedTestCount, int failedTestCount, string reportUrl)
        {

            HTMLMail = "<div id=\":2iz\" class=\"a3s aXjCH m161702855e7923ef\"><u></u>" +
      "  <div>" +
      "    <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"background:#f3f3f3;width:600px;padding-bottom:40px\">" +
      "      <tbody><tr>" +
      "        <td width=\"100%\" align=\"center\" height=\"69px\">" +
      "          <img alt=\"Intro banner\" height=\"69px\" src=\"https://tg-api-test-email.s3.eu-central-1.amazonaws.com/emailLogo.png\" style=\"border:0\" width=\"600px\" class=\"CToWUd\">" +
      "        </td>" +
      "      </tr>" +
      "" +
      "      <tr>" +
      "        <td style=\"padding-left:40px;padding-right:40px\">" +
      "          <table style=\"width:100%\">" +
      "            <tbody><tr>" +
      "              <td style=\"color:green;font-size:25px;font-family:HelveticaNeue;width:250px;height:56px;background-color:#fff;text-align:center;border-radius:3px;vertical-align:middle\" valign=\"center\">" +
      "                <img alt=\"Tick filled\" height=\"26px\" src=\"https://tg-api-test-email.s3.eu-central-1.amazonaws.com/ok.png\" style =\"border:0;vertical-align:middle;padding-right:5px\" width=\"26px\" class=\"CToWUd\">" +
      "                <span style=\"vertical-align:middle;display:inline-block\">Test Passed: " + passedTestCount + "</span>" +
      "              </td>" +
      "              <td style=\"color:red;font-size:25px;font-family:HelveticaNeue;width:250px;height:56px;background-color:#fff;text-align:center;border-radius:3px;vertical-align:middle\" valign=\"center\">" +
      "                  <img alt=\"Error\" height=\"26px\" src=\"https://tg-api-test-email.s3.eu-central-1.amazonaws.com/failed.png\" style=\"border:0;vertical-align:middle;padding-right:5px\" width=\"26px\" class=\"CToWUd\"><span style=\"vertical-align:middle;display:inline-block\">Test Failed: " + failedTestCount + "</span>" +
      "                </td>" +
      "            </tr>" +
      "          </tbody></table>" +
      "          <table style=\"width:100%;border-collapse:collapse\">" +
      "              <tbody><tr style=\"height:20px\"></tr>" +
      "              <tr>" +
      "                <td style=\"font-size:25px;font-family:HelveticaNeue;width:48%;height:56px;background-color:#fff;text-align:center;border-radius:3px;vertical-align:middle\" valign=\"center\">" +
      "                  <span style=\"vertical-align:middle;display:inline-block;color:#009cfc\">Test Total: " + (passedTestCount + failedTestCount) + "</span>" +
      "                </td>" +
      "                <td style=\"width:4%;background-color:#fff\"></td>" +
      "                <td style=\"color:#333;width:48%;height:56px;background-color:#fff;text-align:center;border-radius:3px;vertical-align:middle\" valign=\"center\">" +
      "                  <span style=\"vertical-align:middle;display:inline-block\">" +
      "                    <a href=\"http://atm.local.tg.int/Index.html\" style =\"color:#009cfc;font-size:13px;font-family:'HelveticaNeue',sans-serif;text-decoration:none;vertical-align:right\" target=\"_blank\">Click to got to ATM</span></a></span>" +
      "                </td>" +
      "              </tr>" +
      "          </tbody></table>" +
      "        </td>" +
      "      </tr>" +
      "" +
      "" +
      "" +
      "      <tr style=\"text-align:center\">" +
      "        <td style=\"padding-left:43px;padding-right:43px;padding-top:20px;padding-bottom:45px\">" +
      "            <a href=\"" + reportUrl + "\" style=\"color:#fff;background:#009cfc;border-radius:3px;padding:1em 20px;line-height:42px;min-height:42px;font-size:13px;font-family:'HelveticaNeue',sans-serif;text-decoration:none;border:1px solid #009cfc\" target=\"_blank\">Go to test report</a>" +
      "        </td>" +
      "      </tr>" +
      "          </tbody></table>" +
      "        </td>" +
      "      </tr>" +
      "    </tbody></table>" +
      "" +
      "    " +
      "  <img width=\"1px\" height=\"1px\" alt=\"\" src=\"https://ci5.googleusercontent.com/proxy/aRl2Qk_a4WIFluzc1TqWg9VopkA2QxHz2szr5eoYooefaSq8t0zHBy94hO0Qcku4xUdcewzZ6ExM_YEmvySMCoQ_4U4lrly9zJP-3jDiLHgmYcDzpou7p9m-V3bK8lI1FAJWzvFAUp_TKr_JM_ZVeHAbAg3cJ1sovaNadrQPFcYxPIlC0S7Bm0kV6atNYgVQxNC7PwkskTP7iEtCWwX1CMcBm-Fdlnsy8A6DuZfxbx7lx7g3MttAEAPl8q9I3mahG_1F0CkiqT_cOBTeXU7CAZSojULYhkkpQ3JFAUsbeDU2iRJ9174aeUH_m7p-6eMZhWlovm2rmsfmVohY6U9rHfs=s0-d-e1-ft#http://email.browserstack.com/o/eJxtzEEOwiAQQNHTyJJQWgos2HgFD9AMMFXSUnQKmt7eunf7k_-iU15FzZJToAG9tWqQ6Kc-yK6ToG0YrBVyvgyCYMFpnKj5Q0rFPZXPjrRXCAsPJfMMaWUPhyqO5-cRjcGInfEmCJxn23ulMQhGDl4tbRU2ONVQ6MkrwRvXO26p_ChWXTyx49rSGm8tZ6DjX_sCWeRALg\" class=\"CToWUd\"></div><div class=\"yj6qo\"></div><div class=\"adL\">" +
      "" +
      "</div></div>";
        }

    }
}

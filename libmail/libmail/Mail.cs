using System.Net.Mail;
using System.Net;
using System.IO;
using System;

namespace HenryQuan
{
    public class Mail
    {
        const string CONFIG_NAME = "mail.config";

        static void createConfig()
        {
            using (var writter = new StreamWriter(CONFIG_NAME))
            {
                writter.WriteLine("host=");
                writter.WriteLine("user=");
                writter.WriteLine("password=");
                // writter.WriteLine("port=");
                writter.WriteLine("from=");
                writter.Close();
            }
        }

        [DllExport]
        static bool SendEmail(string subject, string body, string to)
        {
            var host = "";
            var user = "";
            var password = "";
            var from = "";

            if (File.Exists(CONFIG_NAME))
            {
                using (var reader = new StreamReader(CONFIG_NAME))
                {
                    try
                    {
                        host = reader.ReadLine().Split('=')[1];
                        user = reader.ReadLine().Split('=')[1];
                        password = reader.ReadLine().Split('=')[1];
                        from = reader.ReadLine().Split('=')[1];
                        reader.Close();
                    }
                    catch (Exception)
                    {
                        reader.Close();
                        Console.WriteLine("The config isn't valid");
                        return false;
                    }
                    
                }
            }
            else
            {
                createConfig();
                Console.WriteLine("Created the config file");
                return false;
            }

            if (string.IsNullOrEmpty(host) ||
                string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(from))
            {
                Console.WriteLine("Config file contains empty value.");
                return false;
            }

            var message = new MailMessage(from, to, subject, body);
            var client = new SmtpClient(host);
            client.Credentials = new NetworkCredential(user, password);
            client.EnableSsl = true;
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

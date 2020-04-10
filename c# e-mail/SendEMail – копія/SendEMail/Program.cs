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
            Console.WriteLine("Start email Sender v2000");
            Console.WriteLine("Autor : neutron,Boduk,evangelist");
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("ministerosvitu.official@gmail.com", "Міністер");
           
            // кому отправляем
            Console.WriteLine("email target:");
            string target = Console.ReadLine();
            MailAddress to = new MailAddress(target);
            Console.WriteLine("done!");
            // создаем объект сообщения
            Console.WriteLine("email count-:");
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
            for (int i = 0; i < count; i++)
            {
                //Random r = new Random();
                smtp.Send(m);
                //int rd = r.Next(0, 300000);
                //Console.WriteLine("{0 ms}", rd);
                Thread.Sleep(1000);
                Console.WriteLine("mail {0} sended",i+1);
            }
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}   
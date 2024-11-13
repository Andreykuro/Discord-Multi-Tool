using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace dctool
{

    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Title = "dctool";
                Banner();
                Menu();
                
                ConsoleKeyInfo input = Console.ReadKey();
                char option = input.KeyChar;
                Console.WriteLine(option);
                switch (option)
                {
                    case '1':
                        SendWebhookMessage();
                        break;
                    case '4':
                        return;
                }
                
            }    
        }
        static void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
 █████╗ ███╗   ██╗██████╗ ██████╗ ███████╗██╗   ██╗    ██████╗  ██████╗████████╗ ██████╗  ██████╗ ██╗
██╔══██╗████╗  ██║██╔══██╗██╔══██╗██╔════╝╚██╗ ██╔╝    ██╔══██╗██╔════╝╚══██╔══╝██╔═══██╗██╔═══██╗██║
███████║██╔██╗ ██║██║  ██║██████╔╝█████╗   ╚████╔╝     ██║  ██║██║        ██║   ██║   ██║██║   ██║██║
██╔══██║██║╚██╗██║██║  ██║██╔══██╗██╔══╝    ╚██╔╝      ██║  ██║██║        ██║   ██║   ██║██║   ██║██║
██║  ██║██║ ╚████║██████╔╝██║  ██║███████╗   ██║       ██████╔╝╚██████╗   ██║   ╚██████╔╝╚██████╔╝███████╗
╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝╚══════╝   ╚═╝       ╚═════╝  ╚═════╝   ╚═╝    ╚═════╝  ╚═════╝ ╚══════╝
                                                                                         dctool @Andreykuro on Github https://github.com/Andreykuro  ");
            
        }

        static void Menu()
        {
            Console.WriteLine("\n1. Send a Webhook Message");
            Console.WriteLine("2. View Guild Information");
            Console.WriteLine("3. Check Member Status");
            Console.WriteLine("4. Exit");
        }

        static async void SendWebhookMessage()
        {
            Console.Clear();
            Console.Write("Webhook URL: ");
            string webhook = Console.ReadLine();
            
            Console.WriteLine("Message: ");
            string message = Console.ReadLine();

            string json = $"{{\"content\":\"{message}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                client.PostAsync(webhook, content).Wait();
            }
        }
    }
}

﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace FirstNetCore
{
    public interface IMessage
    {
        void Write(string message);
    }
    public class ConsoleMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"訊息: {message} 已經寫入到螢幕上了");
        }
    }
    public class FileMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"訊息: {message} 已經寫入到檔案上了");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceProvider = new ServiceCollection();
            serviceProvider.AddScoped<IMessage, ConsoleMessage>();
            IServiceProvider container =  serviceProvider.BuildServiceProvider();

            IMessage message = container.GetService<IMessage>();
            message.Write("Hi Vulcan");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}

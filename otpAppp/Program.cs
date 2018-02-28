using OtpSharp;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Base32;


namespace otpAppp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            Console.Write("Input key: ");
            string key = Console.ReadLine();

            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    byte[] decodedKey = Base32Encoder.Decode(key);
                    var otp = new Totp(decodedKey);

                    Log.Information(otp.ComputeTotp());

                    Thread.Sleep(1000);
                }

            }, TaskCreationOptions.LongRunning);

            Task.WaitAll(task);
            Console.ReadKey();
        }
    }
}

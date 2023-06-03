using Hangfire;
using Hangfire.SqlServer;
using System;
using System.IO;
using System.IO.Compression;

namespace app
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Hangfire sql server config
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=CENTAURI\\SQLEXPRESS;Initial Catalog=Ex;Integrated Security=True;TrustServerCertificate=True");

            // Hangfire is started
            using (var server = new BackgroundJobServer())
            {
                // Planning a job
                RecurringJob.AddOrUpdate("FileCopyJob", () => CopyFiles(), Cron.Minutely);

                Console.WriteLine("Çalışan bir iş var. Çıkmak için herhangi bir tuşa basın...");
                Console.ReadKey();
            }
        }

        public static void CopyFiles()
        {
            
            string sourceFolder = "C:\\Users\\ayser\\source\\repos\\Turkcell-GYGY-.NET-Bootcamp\\Hangfire\\Example\\data\\source";
            string destinationFolder = "C:\\Users\\ayser\\source\\repos\\Turkcell-GYGY-.NET-Bootcamp\\Hangfire\\Example\\data\\backup";
            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(destinationFolder, DateTime.Now.ToString("yyyyMMdd_HHmmss_") + fileName);
                File.Copy(file, destinationPath);
            }
        }
    }
}

using Hangfire;
using Hangfire.SqlServer;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;


namespace app
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string sourceFolder = "C:\\Users\\ayser\\source\\repos\\Turkcell-GYGY-.NET-Bootcamp\\Hangfire\\Example\\data\\source";
            string destinationFolder = "C:\\Users\\ayser\\source\\repos\\Turkcell-GYGY-.NET-Bootcamp\\Hangfire\\Example\\data\\backup";

            // Hangfire sql server config
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=CENTAURI\\SQLEXPRESS;Initial Catalog=Ex;Integrated Security=True;TrustServerCertificate=True");

            // Hangfire is started
            using (var server = new BackgroundJobServer())
            {
                // Planning a recurring job (in every 1 minute)
                RecurringJob.AddOrUpdate("FileCopyJob", () => CopyFiles(sourceFolder, destinationFolder), Cron.Minutely);

                Console.WriteLine("Yedekleme işlemi başlatıldı. Sonlandırmak için herhangi bir tuşa basın...");
                Console.ReadKey(); 
            }
        }

        public static void CopyFiles(string sourceFolder, string destinationFolder)
        {
            
            string[] files = Directory.GetFiles(sourceFolder);

            // dosyaları başka klasöre yedekleme
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(destinationFolder, DateTime.Now.ToString("yyyyMMdd_HHmmss_") + fileName);
                File.Copy(file, destinationPath);
            }

            BackgroundJob.Enqueue(()=>PrintFileSizes(destinationFolder));
            
        }

        public static void PrintFileSizes(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            long totalSize = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            Console.WriteLine($"Toplam boyut: {totalSize} bytes");
        }

        

    }
}

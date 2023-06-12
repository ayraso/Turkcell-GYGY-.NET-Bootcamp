using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;
using TVRS.Infrastructure.Data_Context;

namespace TVRS.Infrastructure.Data_Seeder
{
    public static class TvrsDbSeeder
    {        
        public static void Seed(TvrsDbContext dbContext)
        {
            seedMainTopicsIfNoExists(dbContext);
            seedSubtopicsIfNoExists(dbContext);
            seedProvincesIfNoExists(dbContext);
            seedDistrictsIfNoExists(dbContext);
            seedInvestigationStatus(dbContext);
            seedUsersIfNoExists(dbContext);
            seedViolationReportsIfNoExists(dbContext);
            seedReportLogsIfNoExists(dbContext);
        }

        private static void seedMainTopicsIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.MainTopics.Any())
            {
                dbContext.MainTopics.AddRange(
                    new MainTopic { Title = "Trafik Kazaları" },
                    new MainTopic { Title = "Araç Muayene" },
                    new MainTopic { Title = "Trafik Levhaları" }
                );

                dbContext.SaveChanges();
            }
        }

        private static void seedSubtopicsIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.Subtopics.Any())
            {
                var mainTopic1 = dbContext.MainTopics.Single(mt => mt.Title == "Trafik Kazaları");
                var mainTopic2 = dbContext.MainTopics.Single(mt => mt.Title == "Araç Muayene");
                var mainTopic3 = dbContext.MainTopics.Single(mt => mt.Title == "Trafik Levhaları");

                dbContext.Subtopics.AddRange(
                    new Subtopic { MainTopicId = mainTopic1.Id, Title = "Kaza Sonucu Yaralananlar" },
                    new Subtopic { MainTopicId = mainTopic1.Id, Title = "Kaza Sonucu Ölenler" },
                    new Subtopic { MainTopicId = mainTopic2.Id, Title = "Araç Muayene Tarihleri" },
                    new Subtopic { MainTopicId = mainTopic2.Id, Title = "Muayenesiz Araçlar" },
                    new Subtopic { MainTopicId = mainTopic3.Id, Title = "Dur-Kalk İşaretleri" },
                    new Subtopic { MainTopicId = mainTopic3.Id, Title = "Hız Sınırları" }
                );

                dbContext.SaveChanges();
            }
        }

        private static void seedProvincesIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.Provinces.Any())
            {
                dbContext.Provinces.AddRange(
                    new Province { Name = "Adana" },
                    new Province { Name = "Adıyaman" },
                    new Province { Name = "Afyonkarahisar" }
                );

                dbContext.SaveChanges();
            }
        }

        private static void seedDistrictsIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.Districts.Any())
            {
                var province1 = dbContext.Provinces.Single(p => p.Name == "Adana");
                var province2 = dbContext.Provinces.Single(p => p.Name == "Adıyaman");
                var province3 = dbContext.Provinces.Single(p => p.Name == "Afyonkarahisar");

                dbContext.Districts.AddRange(
                    new District { ProvinceId = province1.Id, Name = "Seyhan" },
                    new District { ProvinceId = province1.Id, Name = "Yüreğir" },
                    new District { ProvinceId = province2.Id, Name = "Merkez" },
                    new District { ProvinceId = province2.Id, Name = "Besni" },
                    new District { ProvinceId = province3.Id, Name = "Merkez" },
                    new District { ProvinceId = province3.Id, Name = "Bolvadin" }
                );

                dbContext.SaveChanges();
            }
        }

        private static void seedInvestigationStatus(TvrsDbContext dbContext)
        {
            if (!dbContext.InvestigationStatuses.Any())
            {
                dbContext.InvestigationStatuses.AddRange(
                    new InvestigationStatus { Description = "İhbarınız alındı" },
                    new InvestigationStatus { Description = "İhbarınız inceleniyor" },
                    new InvestigationStatus { Description = "Cezai yaptırım uygulandı" }
                );

                dbContext.SaveChanges();
            }
        }

        private static void seedUsersIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(
                    new User
                    {
                        Tin = 12345678901, 
                        FirstName = "Ahmet",
                        LastName = "Yılmaz",
                        Password = "123456",
                        Phone = "5555555555",
                        Email = "ahmet@example.com",
                        Address = "İstanbul",
                        Role = "User"
                    });

                dbContext.SaveChanges();
            }
        }

        private static void seedViolationReportsIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.ViolationReports.Any())
            {
                var user = dbContext.Users.Single(u => u.FirstName == "Ahmet");

                dbContext.ViolationReports.AddRange(
                    new ViolationReport
                    {
                        UserId = user.Id,
                        ReportDateTime = DateTime.Now,
                        SubtopicId = 1,
                        DistrictId = 1,
                        IncidentScene = "Kızılay Meydanı",
                        IncidentDateTime = DateTime.Now.AddDays(-1),
                        IncidentDescription = "Kırmızı ışıkta geçti"
                    },
                    new ViolationReport
                    {
                        UserId = user.Id,
                        ReportDateTime = DateTime.Now,
                        SubtopicId = 2,
                        DistrictId = 2,
                        IncidentScene = "Atatürk Caddesi",
                        IncidentDateTime = DateTime.Now.AddDays(-2),
                        IncidentDescription = "Hız sınırını aştı"
                    }
                );

                dbContext.SaveChanges();
            }
        }

        private static void seedReportLogsIfNoExists(TvrsDbContext dbContext)
        {
            if (!dbContext.ReportLogs.Any())
            {
                var status1 = dbContext.InvestigationStatuses.Single(s => s.Description == "İhbarınız alındı");
                var status2 = dbContext.InvestigationStatuses.Single(s => s.Description == "İhbarınız inceleniyor");
                var status3 = dbContext.InvestigationStatuses.Single(s => s.Description == "Cezai yaptırım uygulandı");

                var report1 = dbContext.ViolationReports.Single(r => r.Id == 1);
                var report2 = dbContext.ViolationReports.Single(r => r.Id == 2);

                dbContext.ReportLogs.AddRange(
                    new ReportLog { StatusId = status1.Id, ReportId = report1.Id, Note = "İhbar alındı", DateTime = DateTime.Now.AddDays(-1) },
                    new ReportLog { StatusId = status2.Id, ReportId = report1.Id, Note = "İhbar inceleniyor", DateTime = DateTime.Now },
                    new ReportLog { StatusId = status3.Id, ReportId = report1.Id, Note = "Cezai yaptırım uygulandı", DateTime = DateTime.Now.AddDays(1) },
                    new ReportLog { StatusId = status1.Id, ReportId = report2.Id, Note = "İhbar alındı", DateTime = DateTime.Now.AddDays(-2) },
                    new ReportLog { StatusId = status2.Id, ReportId = report2.Id, Note = "İhbar inceleniyor", DateTime = DateTime.Now.AddDays(-1) }
                    
                );

                dbContext.SaveChanges();
            }
        }

    }
}

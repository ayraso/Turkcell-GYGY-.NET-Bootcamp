using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Application.DTOs.Requests;
using TVRS.Application.DTOs.Responses;
using TVRS.Application.Extensions;
using TVRS.Domain.Entities;

namespace TVRS.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<NewUserRequest, User>();
            CreateMap<User, DisplayUserResponse>();

            CreateMap<MainTopic, DisplayMainTopicResponse>();
            CreateMap<Subtopic,  DisplaySubtopicResponse>();
            CreateMap<Province, DisplayProvinceResponse>();
            CreateMap<District, DisplayDistrictResponse>();
            CreateMap<InvestigationStatus, DisplayInvestigationStatusResponse>();

            CreateMap<NewViolationReportRequest, ViolationReport>()
                .ForMember(dest => dest.IncidentDateTime, 
                opt => opt.MapFrom(src => DateTime.ParseExact($"{src.IncidentDate} {src.IncidentTime}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ReportDateTime, opt => opt.MapFrom(src => src.ReportDate));

            CreateMap<ViolationReport, DisplayViolationReportResponse>()
                .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDateTime))
                .ForMember(dest => dest.SubtopicName, opt => opt.MapFrom(src => src.Subtopic.Title));
            

            CreateMap<ViolationReport, DisplayDetailedViolationReportResponse>()
                .ForMember(dest => dest.MainTopicTitle, 
                            opt => opt.MapFrom(src => src.Subtopic.MainTopic.Title))
                .ForMember(dest => dest.SubtopicTitle, 
                           opt => opt.MapFrom(src => src.Subtopic.Title))
                .ForMember(dest => dest.ProvinceName, 
                           opt => opt.MapFrom(src => src.District.Province.Name))
                .ForMember(dest => dest.DistrictName, 
                           opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.InvestigationStatusName, 
                           opt => opt.MapFrom(src => src.ReportLogs.OrderByDescending(rl => rl.DateTime)
                                                                   .FirstOrDefault().InvestigationStatus.Description))
                .ForMember(dest => dest.InvestigationStatusLastUpdateDateTime, 
                           opt => opt.MapFrom(src => src.ReportLogs.OrderByDescending(rl => rl.DateTime)
                                                                   .FirstOrDefault().DateTime.ToString("yyyy-MM-dd HH:mm")));
            
            CreateMap<DeleteViolationReportRequest, ViolationReport>();
            CreateMap<UpdateViolationReportRequest, ViolationReport>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<DeleteReportLogRequest, ReportLog>();
            CreateMap<UpdateViolationReportRequest, ReportLog>();
            CreateMap<ViolationReport, ReportLog>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.ReportDateTime));

        }
    }
}

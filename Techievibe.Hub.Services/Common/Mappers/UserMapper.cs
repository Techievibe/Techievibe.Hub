using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Techievibe.Hub.Common.DataModels;
using Api = Techievibe.Hub.Common.ApiModels;

namespace Techievibe.Hub.Services.Common.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<Api.User, Data.User>()
                .ForMember(x => x.USR_ID, opts => opts.MapFrom(y => y.Id))
                .ForMember(x => x.USR_UNAME, opts => opts.MapFrom(y => y.UserName))
                .ForMember(x => x.USR_EMAIL, opts => opts.MapFrom(y => y.Email))
                .ForMember(x => x.USR_PWD, opts => opts.MapFrom(y => y.Password))
                .ForMember(x => x.USR_SGNUP_TYPE, opts => opts.MapFrom(y => y.SignUpType))
                .ForMember(x => x.USR_ADMN_FLG, opts => opts.MapFrom(y => y.IsAdmin))
                .ForMember(x => x.USR_ACT_FLG, opts => opts.MapFrom(y => y.IsActive))
                .ForMember(x => x.USR_F_NM, opts => opts.MapFrom(y => y.FirstName))
                .ForMember(x => x.USR_L_NM, opts => opts.MapFrom(y => y.LastName))
                .ForMember(x => x.CRT_DT, opts => opts.MapFrom(y => y.CreatedDate))
                .ForMember(x => x.UPD_DT, opts => opts.MapFrom(y => y.UpdatedDate));

            CreateMap<Data.User, Api.User>()
                .ForMember(x => x.Id, opts => opts.MapFrom(y => y.USR_ID))
                .ForMember(x => x.UserName, opts => opts.MapFrom(y => y.USR_UNAME))
                .ForMember(x => x.Email, opts => opts.MapFrom(y => y.USR_EMAIL))
                .ForMember(x => x.Password, opts => opts.MapFrom(y => y.USR_PWD))
                .ForMember(x => x.SignUpType, opts => opts.MapFrom(y => y.USR_SGNUP_TYPE))
                .ForMember(x => x.IsAdmin, opts => opts.MapFrom(y => y.USR_ADMN_FLG))
                .ForMember(x => x.IsActive, opts => opts.MapFrom(y => y.USR_ACT_FLG))
                .ForMember(x => x.FirstName, opts => opts.MapFrom(y => y.USR_F_NM))
                .ForMember(x => x.LastName, opts => opts.MapFrom(y => y.USR_L_NM))
                .ForMember(x => x.CreatedDate, opts => opts.MapFrom(y => y.CRT_DT))
                .ForMember(x => x.UpdatedDate, opts => opts.MapFrom(y => y.UPD_DT));
        }
    }
}

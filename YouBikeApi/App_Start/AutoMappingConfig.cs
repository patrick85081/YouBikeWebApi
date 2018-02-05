using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using YouBikeApi.Models;
using YouBikeApi.Models.Service;

namespace YouBikeApi
{
    public class AutoMappingConfig
    {
        const string DateTimeFormat = "yyyyMMddHHmmssfff";
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<YouBikeStationModel, YouBikeStationDto>()
                    .ForMember(d => d.No, o => o.MapFrom(s => s.No))
                    .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                    .ForMember(d => d.Area, o => o.MapFrom(s => s.Area))
                    .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                    .ForMember(d => d.Total, o => o.MapFrom(s => s.Total))
                    .ForMember(d => d.Bikes, o => o.MapFrom(s => s.Bikes))
                    .ForMember(d => d.BikeEmpty, o => o.MapFrom(s => s.BikeEmpty))
                    .ForMember(d => d.Latitude, o => o.MapFrom(s => s.Latitude))
                    .ForMember(d => d.Longitude, o => o.MapFrom(s => s.Longitude))
                    .ForMember(d => d.NameEnglish, o => o.MapFrom(s => s.NameEnglish))
                    .ForMember(d => d.AreaEnglish, o => o.MapFrom(s => s.AreaEnglish))
                    .ForMember(d => d.AddressEnglish, o => o.MapFrom(s => s.AddressEnglish))
                    .ForMember(d => d.Active, o => o.MapFrom(s => s.Active.Equals("1")))
                    .ForMember
                    (
                        d => d.ModifyTime,
                        o => o.MapFrom
                        (
                            s => string.IsNullOrWhiteSpace(s.ModifyTime)
                                ? DateTime.MinValue
                                : DateTime.ParseExact($"{s.ModifyTime}000", DateTimeFormat,
                                    CultureInfo.InvariantCulture)
                        )
                    );
            });

        }
    }
}
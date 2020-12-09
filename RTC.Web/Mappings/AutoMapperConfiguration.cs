using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTC.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static IMapper mapper { get; private set; }
        public static void Configure()
        {
            /*Mapper.Initialize(x =>
            {
                x.AddProfile<MappingConfig>();
            });*/
            var config = new MapperConfiguration(cfg =>
           {
               cfg.AddProfile<MappingConfig>();
           });

            mapper = config.CreateMapper();
            // Config chay vao bootstrapper, bootstrapper chay vao global.asx
        }
    }
}
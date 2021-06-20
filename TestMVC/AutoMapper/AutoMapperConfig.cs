using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TestMVC.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper CreateMapperConfig()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }

        public static void CopyObject<T>(object sourceObject, ref T destObject)
        {
            //  If either the source, or destination is null, return
            if (sourceObject == null || destObject == null)
                return;

            //  Get the type of each object
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            //  Loop through the source properties
            foreach (PropertyInfo p in sourceType.GetProperties())
            {
                //  Get the matching property in the destination object
                PropertyInfo targetObj = targetType.GetProperty(p.Name);
                //  If there is none, skip
                if (targetObj == null)
                    continue;

                //  Set the value in the destination
                targetObj.SetValue(destObject, p.GetValue(sourceObject, null), null);
            }
        }
    }
}

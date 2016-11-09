using eh.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgent.Model;

namespace TravelAgent.WebAPI.Models
{
    public class RefsFileDto
    {
        [Col("A")]
        public string Name { get; set; }
        [Col("B")]
        public string SchName { get; set; }
        [Col("C")]
        public string Tel { get; set; }

        public static IList<RefsFileDto> ToDtos(IList<ReferencesSchool> list)
        { 
            if(list != null && list.Count > 0)
            {
                IList<RefsFileDto> dtoList = new List<RefsFileDto>();
                foreach (var item in list)
                {
                    dtoList.Add(new RefsFileDto(){ Tel = item.Tel, SchName = item.SName, Name = item.RName});
                }
                return dtoList;
            }
            
            return new List<RefsFileDto>();
        }
    }
}
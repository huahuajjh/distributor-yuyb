using eh.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgent.Model;

namespace TravelAgent.WebAPI.Models
{
    public class SchoolCodeFileDto
    {
        [Col("B")]
        public int Id { get; set; }

        [Col("A")]
        public string Name { get; set; }

        public static IList<SchoolCodeFileDto> ToList(IList<School> list)
        {
            IList<SchoolCodeFileDto> dto_list = new List<SchoolCodeFileDto>();
            foreach (School item in list)
            {
                dto_list.Add(new SchoolCodeFileDto() { Id = item.Id, Name = item.Name });
            }
            return dto_list;
        }
    }
}
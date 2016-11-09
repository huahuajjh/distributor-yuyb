using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgent.Model
{
    public class ReferencesSchool
    {
        /// <summary>
        /// references's id
        /// </summary>
        public int RId { get; set; }

        /// <summary>
        /// references's name
        /// </summary>
        public string RName { get; set; }

        /// <summary>
        /// references's tel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// school's id
        /// </summary>
        public int SId { get; set; }

        /// <summary>
        /// school's name
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// school's shortname
        /// </summary>
        public string SShortName { get; set; }

        /// <summary>
        /// school's areaid
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// return school name + references name
        /// </summary>
        public string FullName 
        {
            get
            { 
                return SShortName+"-"+RName;
            }
            set
            { 
                
            }
         }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.IDAL;
using TravelAgent.Model;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
    public class ReferencesSchoolDao:IReferencesSchoolDao
    {
        public IList<ReferencesSchool> GetByFuzzyName(string fuzzy)
        {
            if (string.IsNullOrEmpty(fuzzy)) { fuzzy="";}

           string sql = string.Format("SELECT TOP 20 * FROM v_sch_refs WHERE SName LIKE '%{0}%' OR RName LIKE '%{0}%'",fuzzy);

           DataSet set = DbHelperSQL.Query(sql);

           return DbHelperSQL.DT2List<ReferencesSchool>(set.Tables[0]);
        }


        public IList<ReferencesSchool> GetBySchoolId(int schId)
        {
            string sql = "SELECT * FROM v_sch_refs WHERE SId="+schId;

            DataSet set = DbHelperSQL.Query(sql);

            return DbHelperSQL.DT2List<ReferencesSchool>(set.Tables[0]);
        }

        public IList<ReferencesSchool> GetBySchoolId(int schId, int index, int count, out int total)
        {
            total = DbHelperSQL.Count("v_sch_refs");

            string sql = string.Format("SELECT * FROM v_sch_refs WHERE SId={0} ORDER BY RId OFFSET {1} ROW FETCH NEXT {2} ROWS ONLY", 
            schId, 
            (index - 1)*count,
            count);

            DataSet set = DbHelperSQL.Query(sql);

            return DbHelperSQL.DT2List<ReferencesSchool>(set.Tables[0]);
        }


        public IList<ReferencesSchool> GetAll()
        {
            DataSet set = DbHelperSQL.Query("select RName,Tel, SName from v_sch_refs");

            if(set != null && set.Tables.Count >0)
            {
                return DbHelperSQL.DT2List<ReferencesSchool>(set.Tables[0]);
            }

            return new List<ReferencesSchool>() { new ReferencesSchool()};
        }
    }
}

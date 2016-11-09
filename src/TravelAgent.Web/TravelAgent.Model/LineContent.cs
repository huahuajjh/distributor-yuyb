using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class LineContent
    {
        private int _id = 0;
        private string _title = "";
        private int _morn = 0;
        private int _noon = 0;
        private int _night = 0;
        private string _accom = "";
        private string _content = "";
        private int _daysort = 0;
        private int _lineid = 0;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title= value; }
            get { return _title; }
        }
        /// <summary>
        /// 是否含早餐
        /// </summary>
        public int Morn
        {
            set { _morn = value; }
            get { return _morn; }
        }
        /// <summary>
        /// 是否含中餐
        /// </summary>
        public int Noon
        {
            set { _noon = value; }
            get { return _noon; }
        }
        /// <summary>
        /// 是否含晚餐
        /// </summary>
        public int Night
        {
            set { _night = value; }
            get { return _night; }
        }
        /// <summary>
        /// 住宿
        /// </summary>
        public string Accom
        {
            set { _accom = value; }
            get { return _accom; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 第几天
        /// </summary>
        public int DaySort
        {
            set { _daysort = value; }
            get { return _daysort; }
        }
        /// <summary>
        ///线路编号
        /// </summary>
        public int LineId
        {
            set { _lineid = value; }
            get { return _lineid; }
        }
    }
}

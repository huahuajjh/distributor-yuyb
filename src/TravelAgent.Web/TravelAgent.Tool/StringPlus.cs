using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;

namespace TravelAgent.Tool
{
    public class StringPlus
    {
        #region 将字符串转换为数组
        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[',']);
        }
        #endregion

        #region 将数组转换为字符串
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 删除最后结尾的一个逗号
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        #endregion

        #region 删除最后结尾的指定字符后的字符
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        #endregion

        #region 生成指定长度的字符串
        /// <summary>
        /// 生成指定长度的字符串,即生成strLong个str字符串
        /// </summary>
        /// <param name="strLong">生成的长度</param>
        /// <param name="str">以str生成字符串</param>
        /// <returns></returns>
        public static string StringOfChar(int strLong, string str)
        {
            string ReturnStr = "";
            for (int i = 0; i < strLong; i++)
            {
                ReturnStr += str;
            }

            return ReturnStr;
        }
        #endregion

        #region 生成日期随机码
        /// <summary>
        /// 生成日期随机码
        /// </summary>
        /// <returns></returns>
        public static string GetRamCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }
        #endregion

        #region 截取字符长度
        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="inputString">字符</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号 
            //byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            //if (mybyte.Length > len)
            //    tempString += "...";
            return tempString;
        }
        #endregion

        #region 清除HTML标记
        public static string DropHTML(string Htmlstring)
        {
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        #region 清除HTML标记且返回相应的长度
        public static string DropHTML(string Htmlstring, int strLen)
        {
            return CutString(DropHTML(Htmlstring), strLen);
        }
        #endregion

        #region TXT代码转换成HTML格式
        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把TXT代码转换成HTML格式
        public static String ToHtml(string Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\r\n", "<br />");
            sb.Replace("\n", "<br />");
            sb.Replace("\t", " ");
            //sb.Replace(" ", "&nbsp;");
            return sb.ToString();
        }
        #endregion

        #region HTML代码转换成TXT格式
        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把HTML代码转换成TXT格式
        public static String ToTxt(String Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&nbsp;", " ");
            sb.Replace("<br>", "\r\n");
            sb.Replace("<br>", "\n");
            sb.Replace("<br />", "\n");
            sb.Replace("<br />", "\r\n");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&amp;", "&");
            return sb.ToString();
        }
        #endregion

        #region 检查危险字符
        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if (sInput == null || sInput == "")
                return null;
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output;
        }
        #endregion

        #region 过滤特殊字符
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if (Input != string.Empty && Input != null)
            {
                string ihtml = Input.ToLower();
                ihtml = ihtml.Replace("<script", "&lt;script");
                ihtml = ihtml.Replace("script>", "script&gt;");
                ihtml = ihtml.Replace("<%", "&lt;%");
                ihtml = ihtml.Replace("%>", "%&gt;");
                ihtml = ihtml.Replace("<$", "&lt;$");
                ihtml = ihtml.Replace("$>", "$&gt;");
                return ihtml;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region 过滤特殊字符
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string FilterStr(string Input)
        {
            if (Input == null || Input == "")
                return null;
            return Htmls(Filter(Input));
        }
        #endregion

        #region 获取字符串的实际长度
        /// <summary>
        /// 获取字符串的实际长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串的字节长度</returns>
        public static int TrueLength(string str)
        {
            byte[] bytStr = System.Text.Encoding.Default.GetBytes(str);
            return bytStr.Length;
        }
        #endregion

        #region 按字节从左到右始截取字符串
        /// <summary>
        /// 按字节从左到右始截取字符串
        /// </summary>
        /// <param name="strOriginal">原始字符串</param>
        /// <param name="maxTrueLength">要截取的字节长度</param>
        /// <param name="chrPad">截取后要添加的字符</param>
        /// <returns>截断后的字符串加上要添加的字符</returns>
        public static string LeftTrueLen(string strOriginal, int maxTrueLength, string chrPad)
        {
            if (strOriginal == null || maxTrueLength <= 0)
            {
                return "";
            }
            int originallyLen = TrueLength(strOriginal);      //得到原始字符串的字节长度

            if (originallyLen > maxTrueLength)//超过maxTrueLength
            {
                int length = strOriginal.Length;         // 总的字符长度
                int i = maxTrueLength / 2 - 1;
                if (i < 0) { i = 0; }
                while (i <= maxTrueLength)
                {
                    string strNew = strOriginal.Substring(0, i);
                    int tempLength = TrueLength(strNew);
                    if (tempLength == maxTrueLength)
                    {
                        return strNew += chrPad;
                    }
                    if (tempLength - 1 == maxTrueLength)
                    {
                        return strOriginal.Substring(0, i - 1) + chrPad;
                    }
                    strNew = null;
                    i++;
                }
            }
            return strOriginal;
        }
        /// <summary> 
        /// 计算密码强度 
        /// </summary> 
        /// <param name="password">密码字符串</param> 
        /// <returns></returns> 
        public static EnumSummary.Strength PasswordStrength(string password) 
        {     
            //空字符串强度值为0     
            if (password == "") return EnumSummary.Strength.Invalid;       
            //字符统计     
            int iNum = 0, iLtt = 0, iSym = 0;     
            foreach (char c in password)     
            {         
                if (c >= '0' && c <= '9') iNum++;         
                else if (c >= 'a' && c <= 'z') iLtt++;         
                else if (c >= 'A' && c <= 'Z') iLtt++;         
                else iSym++;     
            }
            if (iLtt == 0 && iSym == 0) return EnumSummary.Strength.Weak; 
            //纯数字密码     
            if (iNum == 0 && iLtt == 0) return EnumSummary.Strength.Weak; 
            //纯符号密码     
            if (iNum == 0 && iSym == 0) return EnumSummary.Strength.Weak; 
            //纯字母密码     
            if (password.Length <= 6) return EnumSummary.Strength.Weak;   
            //长度不大于6的密码     
            if (iLtt == 0) return EnumSummary.Strength.Normal; 
            //数字和符号构成的密码     
            if (iSym == 0) return EnumSummary.Strength.Normal; 
            //数字和字母构成的密码     
            if (iNum == 0) return EnumSummary.Strength.Normal; 
            //字母和符号构成的密码     
            if (password.Length <= 10) return EnumSummary.Strength.Normal; 
            //长度不大于10的密码     
            return EnumSummary.Strength.Strong; 
            //由数字、字母、符号构成的密码 
        }
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetRandString(int len)
        {
            //string s = "0123456789";
            string s = "0123456789";
            string str = "";
            Random r = new Random();
            for (int i = 0; i < len; i++)
            {
                str += s.Substring(r.Next(s.Length), 1);
            }
            return str;
        }
        #endregion
    }
}

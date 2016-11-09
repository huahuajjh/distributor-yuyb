using System;
using System.Data;
using System.Configuration;
using System.Text;

namespace TravelAgent.Tool
{
    /// <summary>
    /// 处理数据类型转换，数制转换、编码转换相关的类
    /// </summary>    
    public sealed class ConvertHelper
    {
        #region 补足位数
        /// <summary>
        /// 指定字符串的固定长度，如果字符串小于固定长度，
        /// 则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        public static string RepairZero( string text,int limitedLength )
        {
            //补足0的字符串
            string temp = "";
            
            //补足0
            for ( int i = 0; i < limitedLength - text.Length; i++ )
            {
                temp += "0";
            }

            //连接text
            temp += text;

            //返回补足0的字符串
            return temp;
        }
        #endregion        

        #region 将数据转换为指定类型
        /// <summary>
        /// 将数据转换为指定类型
        /// </summary>
        /// <param name="data">转换的数据</param>
        /// <param name="targetType">转换的目标类型</param>
        public static object ConvertTo( object data,Type targetType )
        {
            //如果数据为空，则返回
            if ( ValidationHelper.IsNullOrEmpty( data ) )
            {
                return null;
            }

            try
            {
                //如果数据实现了IConvertible接口，则转换类型
                if ( data is IConvertible )
                {
                    return Convert.ChangeType( data, targetType );
                }
                else
                {
                    return data;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将数据转换为指定类型
        /// </summary>
        /// <typeparam name="T">转换的目标类型</typeparam>
        /// <param name="data">转换的数据</param>
        public static T ConvertTo<T>( object data )
        {
            //如果数据为空，则返回
            if ( ValidationHelper.IsNullOrEmpty( data ) )
            {
                return default( T );
            }

            try
            {
                //如果数据是T类型，则直接转换
                if ( data is T )
                {
                    return (T)data;
                }

                //如果数据实现了IConvertible接口，则转换类型
                if ( data is IConvertible )
                {
                    return (T)Convert.ChangeType( data, typeof( T ) );
                }
                else
                {
                    return default( T );
                }
            }
            catch
            {
                return default( T );
            }
        }
        #endregion
    }
}

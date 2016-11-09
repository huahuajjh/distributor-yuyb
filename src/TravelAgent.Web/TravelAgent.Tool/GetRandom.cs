using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Tool
{
    public class GetRandom
    {
        public static int roCount = 0;
        private static char[] constant = 
       { 
            '0','1','2','3','4','5','6','7','8','9', 
            'a','b','c','d','e','f','g','h','i','j','k','m','n','p','q','r','s','t','u','v','w','x','y','z', 
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','P','Q','R','S','T','U','V','W','X','Y','Z' 
        //     由下面所列的字符抽取，如果为了避免出现一些容易混淆的字符，上面的已经筛选
        //    '0','1','2','3','4','5','6','7','8','9', 
        //        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z', 
        //        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' 
        }; 
        /// <summary>
        /// 生成类型
        /// </summary>
        public enum RandomType 
        { 
            All, 
            Number, 
            Uppercased, 
            Lowercased, 
            NumberAndUppercased, 
            NumberAndLowercased, 
            UppercasedAndLowercased, 
        } 
        /// <summary>
        /// 随机生成
        /// </summary>
        /// <param name="Length"></param>
        /// <param name="rt"></param>
        /// <returns></returns>
        public static string GenerateRandom(int Length,RandomType rt) 
        { 
            int initsize=0; 
            int beginsize = 0; 
            int endsize=0; 
            Boolean IsCross=false; 
            switch (rt) 
            { 
                case RandomType.All: 
                { 
                    initsize = constant.Length; //constant数组的最大个数
                    beginsize = 1; //constant数组的开始下标
                    endsize = constant.Length; //constant数组的结束下标
                    //IsCross = false; 
                    break; 
                } 
                case RandomType.Lowercased: 
                { 
                    initsize = 24; //少了2个小写L，0
                    beginsize = 9; 
                    endsize = 32; 
                    //IsCross = false; 
                    break; 
                } 
                case RandomType.Uppercased: 
                { 
                    initsize = 25; //
                    beginsize = 33; 
                    endsize = constant.Length; //constant数组的结束下标
                    // IsCross = false; 
                    break; 
                } 
                case RandomType.Number: 
                { 
                    initsize = 8; 
                    beginsize = 1; 
                    endsize = 8; 
                    //IsCross = false; 
                    break; 
                } 
                case RandomType.UppercasedAndLowercased: 
                { 
                    initsize = constant.Length-8; 
                    beginsize = 9; 
                    endsize = constant.Length; //constant数组的结束下标
                    //IsCross = false; 
                    break; 
                } 
                case RandomType.NumberAndLowercased: 
                { 
                    initsize = 32; 
                    beginsize = 1; 
                    endsize = 32; 
                    //IsCross = false; 
                    break; 
                } 
                case RandomType.NumberAndUppercased: 
                { 
                    IsCross = true; 
                    break; 
                } 
            } 



            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(initsize); 
            Random rd = new Random(unchecked(roCount * (int)DateTime.Now.Ticks));
            roCount++;

            if (!IsCross) 
            { 
                for (int i = 0; i < Length; i++) 
                { 
                    newRandom.Append(constant[rd.Next(beginsize, endsize)]); 
                } 
            } 
            else 
            { 
                for (int i = 0; i < Length; i++) 
                { 
                    newRandom.Append(constant[rd.Next(1, 8)]); 
                    newRandom.Append(constant[rd.Next(33, constant.Length)]); 
                } 
            } 

            return newRandom.ToString(); 
        }
    }
}

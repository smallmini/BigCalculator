using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigCalculator
{
    /// <summary>
    /// 大数，用于计算，内用List<string>char</string>表示数字，前段以'+'、'-'表示正负。
    /// 
    /// 
    /// 减法未完成，所以最好不要调用减法以及负数。。。
    /// </summary>
    class BigNum
    {
        /// <summary>
        /// 表示数字，前段以'+'、'-'表示正负。
        /// </summary>
        List<char> value = new List<char>();
        /// <summary>
        /// 创建一个空 BigNum，以'+'打头。
        /// </summary>
        public BigNum()
        {
            this.value.Add('+');
        }
        /// <summary>
        /// 创建一个 BigNum，根据传入的char[]。
        /// </summary>
        /// <param name="a">要传入的字符数组</param>
        public BigNum(char[] a)
        {
            this.value = new List<char>(a.ToArray());
        }
        /// <summary>
        /// 创建一个 BigNum，根据传入的string。
        /// </summary>
        /// <param name="s">要传入的字符串，可自动加正号</param>
        public BigNum(string s)
        {
            if(s[0]!='+'||s[0] != '-')
            {
                s="+"+s;

            }
            this.value = new List<char>(s.ToArray());
        }
        /// <summary>
        /// 创建一个 BigNum，根据传入的int。
        /// </summary>
        /// <param name="m">传入的整数，自动添加正负</param>
        public BigNum(int m)
        {
            string mm;
            if (m>=0)
            {
                this.value.Add('+');
                mm = "+";
            }
            else
            {
                this.value.Add('-');
                m = -m;
                mm = "-";
            }
            mm += m.ToString();
            char[] mmm = mm.ToArray<char>();
            this.value = new List<char>(mmm.ToArray());

        }
        /// <summary>
        /// 返回大数值
        /// </summary>
        /// <returns>大数值，有正负</returns>
        public string Value()
        {
            return new string(this.value.ToArray());
        }
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="BeAdd">加数</param>
        /// <returns>和</returns>
        public BigNum Add(BigNum BeAdd)
        {
            if(this.value.Count>=BeAdd.value.Count)
            {
                ///
                ///大数加小数
                ///
                BigNum result = new BigNum(this.value.ToArray());
                int temp = 0;
                int up = 0;
                int i = result.value.Count;
                int j = BeAdd.value.Count;
                for (i--,j--; i > 0&&j>=0; i--)
                {
                    if (result.value[i] != '+' &&BeAdd.value[j] != '+')
                    {
                        temp = (int)(result.value[i]) - 48 + (int)(BeAdd.value[j]) - 48 + up;
                        if (temp >= 10)
                        {
                            up = 1;
                            temp -= 10;
                        }
                        else
                        {
                            up = 0;
                        }
                        result.value[i] = (char)(temp + 48);
                        j--;
                    }
                    else if (up == 0)
                    {
                        break;
                    }
                    else if (up == 1)
                    {
                        temp = (int)(result.value[i]) - 48 + 1;
                        if (temp >= 10)
                        {
                            up = 1;
                            temp -= 10;
                        }
                        else
                        {
                            up = 0;
                        }
                        result.value[i] = ((char)(temp + 48));
                    }
                }
                if(up==1)
                {
                    result.value.Insert(1, '1');
                }
                return result;
            }
            else
            {
                return BeAdd.Add(this);
            }
        }
        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="BeMinus">减数</param>
        /// <returns>差</returns>
        public BigNum Minus(BigNum BeMinus)
        {
            BigNum result = new BigNum(this.value.ToArray());

            return result;
        }
    }
}

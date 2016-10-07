using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace BitArray
{
    class BitArray
    {
        private int[] bitArry;
        public BitArray(int size)
        {
            this.bitArry = new int[size];
            for (int i = 0; i < size; i++)
            {
                bitArry[i] = 0;
            }
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 100000)
                {
                    throw new ArgumentOutOfRangeException("Only indeces between 0 and 100.000 are valid");
                }
                else
                {
                    if (this.bitArry[index] == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            set
            {
                if (index < 0 || index > 100000)
                {
                    throw new ArgumentOutOfRangeException("Only indeces between 0 and 100.000 are valid");
                }
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value has to be either 0 or 1");
                }
                else
                {
                    bitArry[index] = value;
                }
            }
        }
        public override string ToString()
        {
            byte[]sb = new byte[100000];
            for (int i = 0; i < this.bitArry.Length; i++)
            {
                sb[i]=Convert.ToByte(bitArry[i]);
            }

            BigInteger num = new BigInteger(sb);
            BigInteger binary_val;
            BigInteger decimal_val = 0;
            int base_val = 1;
            BigInteger rem = new BigInteger();        
            binary_val = num;
            while (num > 0)
            {
                rem = num % 10;
                decimal_val = decimal_val + rem * base_val;
                num = num / 10;
                base_val = base_val * 2;
            }
            return decimal_val.ToString();
        }
    }
}

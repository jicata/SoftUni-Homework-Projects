using System;

namespace WellKnownWoman
{
    class Aide
    {
        static void Main()
        {
            int[] sortedArray = {1,2,3,4,5,6,7,8,9,10};
            
        }

        public int BinarySearch(int[] sortedArray, int targetNumber)
        {
            int[] tempArray = new int[0];
            int medianValue = sortedArray[sortedArray.Length/2];
            int startValue = sortedArray[0];
            int endValue = sortedArray[sortedArray.Length - 1];

            while (startValue < endValue)
            {
                if (targetNumber == medianValue)
                {
                    return medianValue;
                }
                else if (targetNumber > medianValue)
                {
                    for (int i = medianValue; i < endValue; i++)
                    {
                        tempArray[i] = sortedArray[i];
                    }
                    startValue = medianValue;
                    medianValue = tempArray[tempArray.Length/2];
                    endValue = tempArray[tempArray.Length - 1];
                }
                else
                {
                  
                }
            }

            return 1;
        }
    }
}

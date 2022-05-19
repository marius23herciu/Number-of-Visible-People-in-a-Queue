using System;

namespace Number_of_Visible_People_in_a_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //1944. Number of Visible People in a Queue
            //https://leetcode.com/problems/number-of-visible-people-in-a-queue/

            //There are n people standing in a queue, and they numbered from 0 to n - 1 in left to right order. You are given an array heights
            //of distinct integers where heights[i] represents the height of the ith person.
            //A person can see another person to their right in the queue if everybody in between is shorter than both of them.More formally,
            //the ith person can see the jth person if i < j and min(heights[i], heights[j]) > max(heights[i + 1], heights[i + 2], ..., heights[j - 1]).
            //Return an array answer of length n where answer[i] is the number of people the ith person can see to their right in the queue.

            int[] heights = { 10, 6, 8, 5, 11, 9 };
            int[] result = CanSeePersonsCount(heights);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
        public static int[] CanSeePersonsCount(int[] heights)
        {
            int[] personsVisibleToRight = new int[heights.Length];

            for (int i = 0; i < heights.Length - 1; i++)
            {
                int counter = 0;
                int previousBiggest = -1;
                for (int j = i + 1; j < heights.Length; j++)
                {
                    if (heights[i] <= heights[j])
                    {
                        counter++;
                        break;
                    }
                    if (heights[i] > heights[j])
                    {
                        if (heights[i] > heights[j] && heights[j] > previousBiggest)
                        {
                            counter++;
                        }
                        if (previousBiggest < heights[j])
                        {
                            previousBiggest = heights[j];
                        }
                    }
                }
                personsVisibleToRight[i] = counter;
            }
            
            return personsVisibleToRight;
        }
    }
}

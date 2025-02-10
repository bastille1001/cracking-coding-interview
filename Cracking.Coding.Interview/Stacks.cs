namespace Cracking.Coding.Interview
{
    public static class Stacks
    {
        /// <summary>
        /// Valid Parentheses
        /// </summary>
        public static bool IsValid(string s)
        {
            var dict = new Dictionary<char, char>(capacity: 3)
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            var stack = new Stack<char>();

            foreach(var br in s)
            {
                if (dict.ContainsKey(br))
                {
                    if (stack.Count > 0 && stack.Peek() == br)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(br);
                }
            }

            return stack.Count == 0;
        }

        /// <summary>
        /// Generate Parentheses
        /// </summary>
        public static IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();

            string stack = string.Empty;

            BackTrack(0, 0, n, result, stack);

            return result;
        }

        private static void BackTrack(int open, int close, int n, List<string> res, string stack)
        {
            if (open == close && open == n)
            {
                res.Add(stack);
                return;
            }

            if (open < n)
            {
                BackTrack(open + 1, close, n, res, stack + "(");
            }

            if (close < open)
            {
                BackTrack(open, close + 1, n, res, stack + ")");
            }
        }

        /// <summary>
        /// Daily Temperatures
        /// </summary>
        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            var stack = new Stack<int>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int prevIdx = stack.Pop();
                    result[prevIdx] = i - prevIdx;
                }
                stack.Push(i);
            }

            return result;
        }

        /// <summary>
        /// Car Fleet
        /// </summary>
        public static int CarFleet(int target, int[] position, int[] speed)
        {
            int fleets = 1;

            if (position.Length == 1)
            {
                return fleets;
            }

            int n = position.Length;
            int[][] pairs = new int[n][];
            for (int i = 0; i < n; i++)
            {
                pairs[i] = [position[i], speed[i]];
            }

            Array.Sort(pairs, (a, b) => b[0].CompareTo(a[0]));

            double prevTime = (double)(target - pairs[0][0]) / pairs[0][1];

            for (int i = 1; i < n; i++)
            {
                double currTime = (double)(target - pairs[i][0]) / pairs[i][1];
                if (currTime > prevTime)
                {
                    fleets++;
                    prevTime = currTime;
                }
            }

            return fleets;
        }
    }
}
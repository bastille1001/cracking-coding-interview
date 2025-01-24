﻿namespace Cracking.Coding.Interview
{
    public static class ArraysAndStrings
    {
        /// <summary>
        /// Unique: Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsUnique(string word)
        {
            var hs = word.ToHashSet();

            return word.Length == hs.Count;
        }

        /// <summary>
        /// Unique: Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsUnique2(string word)
        {
            var charArr = word.ToCharArray();
            Array.Sort(charArr);

            for (int i = 1; i < charArr.Length; i++)
            {
                if (charArr[i] == charArr[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        // <summary>
        /// Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CheckPermutation(string original, string permutated)
        {
            if (original.Length != permutated.Length)
            {
                return false;
            }

            var dict = new Dictionary<char, int>();

            foreach (char ch in original)
            {
                if (dict.TryGetValue(ch, out int value))
                {
                    dict[ch] = ++value;
                }
                else
                {
                    dict.Add(ch, ++value);
                }
            }

            foreach (var perm in permutated)
            {
                if (dict.TryGetValue(perm, out int value) && !(value <= 0))
                {
                    dict[perm] = --value;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CheckPermutation2(string original, string permutated)
        {
            if (original.Length != permutated.Length)
            {
                return false;
            }

            var originCharArr = original.ToCharArray();
            var permCharArr = permutated.ToCharArray();

            Array.Sort(originCharArr);
            Array.Sort(permCharArr);

            for (int i = 0; i < originCharArr.Length; i++)
            {
                if (originCharArr[i] != permCharArr[i]) 
                { 
                    return false; 
                }
            }

            return true;
        }

        /// <summary>
        /// Group Anagrams: Given an array of strings strs, group all anagrams together into sublists.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static List<List<string>> GroupAnagrams(string[] strs)
        {
            var res = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                int[] count = new int[26];

                foreach (var c in s)
                {
                    count[c - 'a']++;
                }

                var key = string.Join(",", count);

                if (!res.TryGetValue(key, out List<string>? value))
                {
                    value = [];
                    res[key] = value;
                }

                value.Add(s);
            }

            var result = new List<List<string>>();
            foreach (var group in res.Values)
            {
                result.Add(group);
            }

            return result;
        }
    }
}

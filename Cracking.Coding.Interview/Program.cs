namespace Cracking.Coding.Interview
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine($"{nameof(ArraysAndStrings.IsUnique)} returned {ArraysAndStrings.IsUnique("teymure")}");   // IsUnique - Arrays and Strings with HashSet
            Console.WriteLine($"{nameof(ArraysAndStrings.IsUnique2)} returned {ArraysAndStrings.IsUnique2("teymure")}"); // IsUnique - Arrays and Strings without additional data structure



            Console.WriteLine($"{nameof(ArraysAndStrings.CheckPermutation)} returned {ArraysAndStrings.CheckPermutation("teymur", "rteym")}");  // Check Permutation: Given two strings, write a method to decide if one is a permutation of the other with Dictionary
            Console.WriteLine($"{nameof(ArraysAndStrings.CheckPermutation2)} returned {ArraysAndStrings.CheckPermutation2("teymur", "rteym")}"); // Check Permutation: Given two strings, write a method to decide if one is a permutation of the other without additional data structure



            Console.WriteLine(ArraysAndStrings.URLify("Mr John Smith   "));
        }
    }
}

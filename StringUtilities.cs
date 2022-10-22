using System.Collections.Generic;

namespace PureFunctions
{
    /// <summary>
    /// A collection of utility methods to manipulate strings in generic ways.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// This method attempts to reduce the expense of string operations by trying less expensive operations first.
        /// Only use a large strings (like JSON) as there is a chance this can be more expensive (More likely on matching strings).
        /// </summary>
        public static bool StringsMatch(string stringA, string stringB)
        {
            if (string.IsNullOrEmpty(stringA) && string.IsNullOrEmpty(stringB)) return true;

            if (string.IsNullOrEmpty(stringA) && !string.IsNullOrEmpty(stringB)) return false;

            if (!string.IsNullOrEmpty(stringA) && string.IsNullOrEmpty(stringB)) return false;
            
            if (string.IsNullOrEmpty(stringA) || string.IsNullOrEmpty(stringB)) return false;
            
            if (stringA.Length != stringB.Length) return false;

            const int zero = 0;

            if (stringA[zero] != stringB[zero]) return false;

            var randomCharacterCheck = UnityEngine.Random.Range(zero, stringA.Length);
                
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (stringA[randomCharacterCheck] != stringB[randomCharacterCheck]) return false;

            //Looks like we have to do a comparison anyway, operation turned out more expensive that just doing a string comparison :(
            return string.Equals(stringA, stringB);
        }

        public static string AddSpacesBeforeCapitals(string stringToConvert)
        {
            var sentence = new List<char>();
            const char space = ' ';

            for (var i = 0; i < stringToConvert.Length; i++)
            {
                var character = stringToConvert[i];
                
                if (char.IsUpper(character))
                {
                    if (i != 0)
                    {
                        sentence.Add(space);
                    }
                }

                sentence.Add(character);
            }

            return new string(sentence.ToArray());
        }
    }
}

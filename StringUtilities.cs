using System.Collections.Generic;

namespace PureFunctions
{
    public static class StringUtilities
    {
        public static bool StringsMatch(string stringA, string stringB)
        {
            if (string.IsNullOrEmpty(stringA) || string.IsNullOrEmpty(stringB)) return false;
            
            if (stringA.Length != stringB.Length) return false;

            const int zero = 0;

            if (stringA[zero] != stringB[zero]) return false;

            var randomCharacterCheck = UnityEngine.Random.Range(zero, stringA.Length);
                
            if (stringA[randomCharacterCheck] != stringB[randomCharacterCheck]) return false;

            //Looks like we have to do a comparison anyway
            return string.Equals(stringA, stringB);
        }

        public static string AddSpacesBeforeCapitals(string stringToConvert)
        {
            var returnVariable = new List<char>();
            const char space = ' ';

            for (var i = 0; i < stringToConvert.Length; i++)
            {
                var character = stringToConvert[i];
                
                if (char.IsUpper(character))
                {
                    if (i != 0)
                    {
                        returnVariable.Add(space);
                    }
                }

                returnVariable.Add(character);
            }

            return new string(returnVariable.ToArray());
        }
    }
}

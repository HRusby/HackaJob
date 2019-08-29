using System;
using System.Collections.Generic;

namespace Hackajob
{
    public class MorseConverter
    {
        static public string Run(bool morseToEnglish, string textToTranslate)
        {
            Dictionary<string, char> morseToEnglishDict = new Dictionary<string, char>();
            Dictionary<char, string> englishToMorseDict = new Dictionary<char, string>();
            SetUpDictionaries(morseToEnglishDict, englishToMorseDict);
            string result;
            textToTranslate = textToTranslate.ToUpper();
            try
            {
                if (morseToEnglish)
                {
                    return result = MorseToEnglish(morseToEnglishDict, textToTranslate);
                }
                return result = EnglishToMorse(englishToMorseDict, textToTranslate);
            }
            catch (Exception e)
            {
                result = "Invalid Morse Code Or Spacing";
            }
            return result;
        }

        private static void SetUpDictionaries(
            Dictionary<string, char> forwards,
            Dictionary<char, string> reverse)
        {
            Add(".-", 'A', forwards, reverse);
            Add("-...", 'B', forwards, reverse);
            Add("-.-.", 'C', forwards, reverse);
            Add("-..", 'D', forwards, reverse);
            Add(".", 'E', forwards, reverse);
            Add("..-.", 'F', forwards, reverse);
            Add("--.", 'G', forwards, reverse);
            Add("....", 'H', forwards, reverse);
            Add("..", 'I', forwards, reverse);
            Add(".---", 'J', forwards, reverse);
            Add("-.-", 'K', forwards, reverse);
            Add(".-..", 'L', forwards, reverse);
            Add("--", 'M', forwards, reverse);
            Add("-.", 'N', forwards, reverse);
            Add("---", 'O', forwards, reverse);
            Add(".--.", 'P', forwards, reverse);
            Add("--.-", 'Q', forwards, reverse);
            Add(".-.", 'R', forwards, reverse);
            Add("...", 'S', forwards, reverse);
            Add("-", 'T', forwards, reverse);
            Add("..-", 'U', forwards, reverse);
            Add("...-", 'V', forwards, reverse);
            Add(".--", 'W', forwards, reverse);
            Add("-..-", 'X', forwards, reverse);
            Add("-.--", 'Y', forwards, reverse);
            Add("--..", 'Z', forwards, reverse);
            Add(".----", '1', forwards, reverse);
            Add("..---", '2', forwards, reverse);
            Add("...--", '3', forwards, reverse);
            Add("....-", '4', forwards, reverse);
            Add(".....", '5', forwards, reverse);
            Add("-....", '6', forwards, reverse);
            Add("--...", '7', forwards, reverse);
            Add("---..", '8', forwards, reverse);
            Add("----.", '9', forwards, reverse);
            Add("-----", '0', forwards, reverse);
            Add(".-.-.-", '.', forwards, reverse);
        }

        public static string MorseToEnglish(Dictionary<string, char> morseToEnglishDict, string text)
        {
            string returnSentence = string.Empty;
            string[] words = text.Split(new string[] { "   " }, StringSplitOptions.None);
            for (int i = 0; i < words.Length; i++)//string word in words)
            {
                string newWord = string.Empty;
                string[] letters = words[i].Split(' ');
                foreach (string letter in letters)
                {
                    char convertedLetter;
                    if (!morseToEnglishDict.TryGetValue(letter, out convertedLetter))
                    {
                        throw new Exception();
                    }
                    newWord += convertedLetter;
                }
                if (i == 0)
                {
                    returnSentence = newWord;
                    continue;
                }
                returnSentence = string.Join(" ", returnSentence, newWord);
            }
            return returnSentence.ToLower();
        }

        private static void Add(
            string key,
            char val,
            Dictionary<string, char> dictionary,
            Dictionary<char, string> reverseDictionary)
        {
            dictionary.Add(key, val);
            reverseDictionary.Add(val, key);
        }

        public static string EnglishToMorse(Dictionary<char, string> englishToMorseDict, string sentence)
        {
            string returnSentence = string.Empty;
            string[] words = sentence.Split(new string[] { " " }, StringSplitOptions.None);
            string convertedLetter;
            for (int i = 0; i < words.Length; i++)
            {
                string newWord = string.Empty;
                char[] letters = words[i].ToCharArray();
                foreach (char letter in letters)
                {
                    if (!englishToMorseDict.TryGetValue(letter, out convertedLetter))
                    {
                        throw new Exception();
                    }
                    if (newWord == string.Empty) { newWord = convertedLetter; }
                    else { newWord = string.Join(" ", newWord, convertedLetter); }
                }

                if (returnSentence == string.Empty) { returnSentence = newWord; }
                else { returnSentence = string.Join("   ", returnSentence, newWord); }
            }
            return returnSentence;
        }
    }
}


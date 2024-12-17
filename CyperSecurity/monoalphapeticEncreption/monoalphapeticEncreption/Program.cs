using System;
using System.Collections.Generic;

class MonoalphabeticCipher
{
    static void Main()
    {
        Console.WriteLine("Enter the plaintext to encrypt:");
        string plaintext = Console.ReadLine()?.ToUpper();
        string key = GenerateRandomKey();
        Console.WriteLine($"\nGenerated Key: {key}");
        string encryptedText = EncryptText(plaintext, key);
        Console.WriteLine($"\nEncrypted Text: {encryptedText}");
    }


    /// Generates a random substitution key by shuffling the alphabet.
   
    static string GenerateRandomKey()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] letters = alphabet.ToCharArray();
        Random random = new Random();

        // Shuffle the letters using the Fisher-Yates algorithm
        for (int i = letters.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (letters[i], letters[j]) = (letters[j], letters[i]); // Swap letters
        }

        return new string(letters); // Return the shuffled alphabet as the key
    }
    /// Encrypts the plaintext using the generated substitution key
    static string EncryptText(string plaintext, string key)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Dictionary<char, char> substitutionMap = new Dictionary<char, char>();

        // Map
        for (int i = 0; i < alphabet.Length; i++)
        {
            substitutionMap[alphabet[i]] = key[i];
        }

        // Build the encrypted text
        string encryptedText = "";
        foreach (char letter in plaintext)
        {
            if (substitutionMap.ContainsKey(letter)) // Encrypt only alphabetic letters
                encryptedText += substitutionMap[letter];
            else
                encryptedText += letter; // Keep non-alphabetic characters as is
        }

        return encryptedText;
    }
}

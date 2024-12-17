using System;
using System.Collections.Generic;


namespace monoalphapeticDecryption {

class MonoalphabeticCipher
{
    static void Main(string[] args)
    {
        // Ciphertext alphabet (substituted letters)
        string ciphertextAlphabet = "QWERTYUIOPASDFGHJKLZXCVBNM";

        // Plaintext alphabet (original letters)
        string plaintextAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Ciphertext message to decrypt
        Console.Write("Enter the ciphertext to decrypt: ");
        string ciphertext = Console.ReadLine().ToUpper();

        // Decrypt the ciphertext
        string plaintext = DecryptMonoalphabetic(ciphertext, ciphertextAlphabet, plaintextAlphabet);

        Console.WriteLine("Decrypted Plaintext: " + plaintext);
    }

    static string DecryptMonoalphabetic(string ciphertext, string cipherAlphabet, string plainAlphabet)
    {
        Dictionary<char, char> decryptionMap = new Dictionary<char, char>();

        // Create a mapping of ciphertext letters to plaintext letters
        for (int i = 0; i < cipherAlphabet.Length; i++)
        {
            decryptionMap[cipherAlphabet[i]] = plainAlphabet[i];
        }

        // Decrypt the ciphertext
        char[] plaintext = new char[ciphertext.Length];
        for (int i = 0; i < ciphertext.Length; i++)
        {
            char currentChar = ciphertext[i];
            if (decryptionMap.ContainsKey(currentChar))
            {
                plaintext[i] = decryptionMap[currentChar];
            }
            else
            {
                // Keep non-alphabet characters unchanged
                plaintext[i] = currentChar;
            }
        }

        return new string(plaintext);
    }
}
}

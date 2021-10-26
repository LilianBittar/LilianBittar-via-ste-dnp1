using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    class Program
    {
        public static async Task<string> GetWord()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");
            var streamTask = client.GetStringAsync("http://random-word-api.herokuapp.com/word?number=1");
            string result = await streamTask;
            //to print the word without parenteses
            return result.Substring(2, result.Length -4); 
        }
        
        
        
        static void Main(string[] args)
        {
            string word = GetWord().Result;
            Console.WriteLine(word);
          
            StringBuilder letters = new StringBuilder("");
            for (int i = 0; i < word.Length; i++)
            {
                letters.Append('_');
            }

            char input;
            string foundLetters = "";

            while (true)
            {
                Console.WriteLine("Guess a word:");
                Console.WriteLine(letters.ToString());
                Console.WriteLine("Your letter?");
                try
                {
                    input = Char.Parse(Console.ReadLine());
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (input == word[i])
                        {
                            letters[i] = word[i];
                            bool isFound = false;
                            for (int j = 0; j < foundLetters.Length; j++)
                            {
                                if (input == foundLetters[j])
                                {
                                    isFound = true;
                                    break;
                                }
                            }

                            if (!isFound)
                            {
                                foundLetters += input + ", ";
                            }
                        }
                    }
                    Console.WriteLine("Guessed letters so far m" + foundLetters);
                    Console.WriteLine("Result: ");
                    Console.WriteLine(letters.ToString());
                    if (letters.ToString() == word)
                    {
                        Console.WriteLine("yeeey!! word found");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

        }
    }
}
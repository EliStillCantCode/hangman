var goAgain = true;

while (goAgain == true)
{
    var words = File.ReadAllLines(".\\words.txt").Select(word => word.ToUpper()).ToArray();

    var targetWord = words[Random.Shared.Next(words.Length)];

    var partialWord = new char[targetWord.Length];
    for (int i = 0; i < targetWord.Length; i++)
    {
        partialWord[i] = '_';
    }

    var lives = 10;
    var hasWon = false;

    while (lives != 0)
    {
        Console.Clear();
        Console.WriteLine(partialWord);
        Console.Write($"You have {lives} lives left. Guess a letter: ");

        var guess = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (targetWord.Contains(guess))
        {
            for (int i = 0; i < targetWord.Length; i++)
            {
                if (targetWord[i] == guess)
                {
                    partialWord[i] = targetWord[i];
                }
            }
            Console.WriteLine("Correct!");
        }
        else lives--;

        if (!partialWord.Contains('_'))
        {
            hasWon = true;
            break;
        }
    }

    if (hasWon)
    {
        Console.Clear();
        Console.Write("\nWell done! You guessed the word!");
    }
    else
    {
        Console.Clear();
        Console.Write($"\nSorry, you didn't guess the word. The word was '{targetWord}'.");
    } 

    Console.WriteLine("\n\nPlay Again? [y/n]: ");
    var response = Console.ReadLine();
    if (response == "y")
    {
        goAgain = true;

    }
    else
    {
        goAgain = false;

    }

}
// dotnet publish -c Release -r win-x64 --self-contained
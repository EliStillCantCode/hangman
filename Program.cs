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
    Console.WriteLine(partialWord);
    Console.Write($"You have {lives} lives left. Guess a letter: ");

    var guess = char.ToUpper(Console.ReadKey().KeyChar);
    Console.WriteLine();

    /* if (partialWord.Contains(guess))
    {
        haha code
    } */

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
    Console.Write("\nWell done! You guessed the word!");
}
else Console.Write($"\nSorry, you didn't guess the word. The word was '{targetWord}'.");

// exit loop
var keypressed = false;
while (keypressed != true)
{
    Console.WriteLine("\n\nPress any key to exit.");
    Console.ReadKey();
    keypressed = true;
}

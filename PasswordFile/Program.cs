class Program
{
    static void Main(string[] args)
    {
        var path = "C:\\Users\\Admin\\source\\repos\\password\\PasswordFile\\passwords.txt";
        int validPasswordsCount = 0;

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string[] rules = parts[0].Split(' ');
                string[] range = rules[1].Split('-');

                char requiredChar = rules[0][0];

                int minCount = int.Parse(range[0]);
                int maxCount = int.Parse(range[1]);

                string currentPassword = parts[1].Trim();

                int count = 0;
                foreach (char c in currentPassword)
                {
                    if (c == requiredChar)
                    {
                        count++;
                    }
                }

                if (count >= minCount && count <= maxCount)
                {
                    validPasswordsCount++;
                }
            }
        }

        Console.WriteLine($"Count of valid passwords: {validPasswordsCount}");
    }
}
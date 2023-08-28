
internal class Program
{
    static int maxPlayerHP = 40;
    static int playerHP = 40;
    static int goblinHP = 20;
    static int trollHP = 25;
    static int orkHp = 30;
    static string Enemy;
    static int EnemyHP;
    static bool bleed;
    static int shield;
    static int bleedTurns;
    static bool shieldActive;
    static int score = 0;

    private static void Main(string[] args)
    {
        while (playerHP > 0)
        {
            Random random = new Random();
            int Renemy = random.Next(0, 3);
            if (Renemy == 0)
            {
                Enemy = "Goblin";
                EnemyHP = goblinHP;

            }
            else if (Renemy == 1)
            {
                Enemy = "Troll";
                EnemyHP = trollHP;
            }
            else if (Renemy == 2)
            {
                Enemy = "Ork";
                EnemyHP = orkHp;
            }

            while (EnemyHP > 0 && playerHP > 0)
            {
                Dialog();
                string input = Console.ReadLine();
                PlayerAbilities(input);
                EnemyTurns();
                TemporaryEffects();
                Console.Clear();
            }
            score++;
            goblinHP = 20;
            trollHP = 25;
            orkHp = 30;
            Console.Clear();
            if (playerHP > 0) {
                Console.WriteLine($"{Enemy} defeated");
                Console.WriteLine("Player goes to next enemy!");
            }
        }
        Console.WriteLine("PLayer died");
        Console.WriteLine("Score - " + score);

    }
    static void Dialog()
    {
        Console.WriteLine($"Player vs {Enemy}");
        Console.WriteLine($"Player health - {playerHP}, {Enemy} health - {EnemyHP}");
        Console.WriteLine("Player turn\nPress '1'for Basic melee attack(4 - 8 Damage)\n" +
            "Press '2' for bleed melee attack (2damage and 2 damage for next 3 turns\n" +
            "Press '3' for shield(for next turn player have 10+ health)\n" +
            "Press '4' for heal(heal for 5 health permemntly)) ");
    }
    static void PlayerAbilities(string input)
    {
        {
            Random random = new Random();
            if (input == "1")
            {
                int BMdamage = random.Next(4, 9);
                EnemyHP -= BMdamage;
                Console.WriteLine($"Damage delth to {Enemy} - {BMdamage}");
            }
            else if (input == "2")
            {
                bleed = true;
                bleedTurns = 4;
            }
            else if (input == "3")
            {
   
                shield = 1;
                Console.WriteLine("Shield active");
                
            }
            else if (input == "4")
            {
                playerHP += 5;
                maxPlayerHP += 5;
            }
            else
            {
                Console.WriteLine("PLease input valid number!");
            }
        }
    }
    static void TemporaryEffects()
    {
        if (shield == 1)
        {
            playerHP += 10;
            shield = 0;
        }
        else if (shield == 0)
        {
            playerHP -= 10;
            shield = 2;
        }

        if (bleed == true && bleedTurns > 0)
        {
            Console.WriteLine($"Bleeding effect deals 2 damage to {Enemy}");
            EnemyHP -= 2;
            bleedTurns--;
        }

    }
    static void EnemyTurns()
    {
        Random erandom = new Random();
        int enemychoise = erandom.Next(0,2);
        if (Enemy == "Goblin")
        {
            if(enemychoise == 0)
            {
                int damage = erandom.Next(3, 6);
                playerHP -= damage;
                Console.WriteLine($"Goblin attacks for {damage}");
            }
            else
            {
                EnemyHP += 3;
                Console.WriteLine("Goblin heals for 3");
            }

        }
        else if (Enemy == "Troll")
        {
            if (enemychoise == 0)
            {
                int damage = erandom.Next(4, 8);
                playerHP -= damage;
                Console.WriteLine($"Troll attacks for {damage}");
            }
            else
            {
                EnemyHP += 3;
                Console.WriteLine("Troll heals for 3");
            }
        }
        else if (Enemy == "Ork")
        {
            if (enemychoise == 0)
            {
                int damage = erandom.Next(2, 10);
                playerHP -= damage;
                Console.WriteLine($"Ork attacks for {damage}");
            }
            else
            {
                EnemyHP += 3;
                Console.WriteLine("Ork heals for 3");
            }
        }
    }

}

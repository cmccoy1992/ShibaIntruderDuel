using System;

//Shiba Stats
int shibaVitality = 10;
int shibaStrength = 0;
int shibaEvasion = 10;
int shibaAccuracy = 0;
int energy = 10;
string[] shibaMoves = { "Butt Slam", "Bite", "Shiba Scream", "Zoomies", "Judgment Stare", "Suplex" };

//Dice Variables
string action = "";
Random diceRoll = new Random();
int attackRoll = 0;
Random damageRoll = new Random();
int damage = 0;
int total = 0;

//Enemy Variables
string enemyName = "";
int enemyHP = 100;
int enemyMaxHP = 100;
int enemyDamageBonus = 0;
int enemyAccuracy = 0;
int enemyAC = 10;
int enemyAction = 0;
int lootHeld = 0;
string[] enemyMoves = { "", "", "", };
string[] loot = { "Tennis Ball", "Rope", "Dog Treat", "Chicken Nuggets", "Golden Nugget", "Bag of Apples", "Bazooka", "Bag of Worms", "Cheddar Cheese", "Dracula's Cape", "Vampire Killer Whip", "Dog Bed", "Leash", "Lettuce", "Tomato", "Sourdough Bread", "Priceless Artwork", "Aaron's Car Keys", "Hairball", "A Disappointing Salad", "The Black Materia", "Hand of Vecna", "A Filthy Rag", "An Old Shoe", "$20", "Stick of Glue", "Basket of Strawberries", "Typewriter", "Nintendo Switch 2", "Rubber Duck", "Newspaper", "Stick" };

//Status Variables
int zoomiesTimer = -1;
int judgmentTimer = -1;

//Start
Console.WriteLine("The Shiba Inu, Pup-Tart, has found an intruder in his territory and decides that's cause for a fight. \n"); System.Threading.Thread.Sleep(1000);
Console.WriteLine("This battle will operate under D&D combat rules- roll a d20 for attack. If the attack meets or exceeds the opponent's Evasion, they take damage."); System.Threading.Thread.Sleep(1000);
Console.WriteLine("What intruder is Pup-Tart fighting?");
Console.WriteLine("A) \t Cat	  [Easy Difficulty]");
Console.WriteLine("B) \t Shiba    [Medium Difficulty]");
Console.WriteLine("C) \t Baboon   [Hard Difficulty] \n");
Console.WriteLine("Type in A, B, or C for the opponent you want to fight: ");

//Opponent Selection
string opponent = Console.ReadLine();
while ((opponent.ToUpper() != "A") && (opponent.ToUpper() != "B") && (opponent.ToUpper() != "C"))
{
	Console.WriteLine("That is not a valid opponent. Try again.");
	opponent = Console.ReadLine();
}

switch (opponent.ToUpper())
{
    case "A":
        enemyName = "Cat";
        Console.WriteLine($"Opponent: \t {enemyName}");
        enemyMaxHP = 50;
        enemyHP = enemyMaxHP;
        lootHeld = 3;
        Console.WriteLine($"Health: \t   {enemyHP}");
        Console.WriteLine("A pesky cat- always going where they don't belong.");
        enemyMoves[0] = "Cat Scratch"; enemyMoves[1] = "Fangs"; enemyMoves[2] = "Feline Fury";
        break;
    case "B":
        enemyName = "Shiba";
        Console.WriteLine($"Opponent: \t {enemyName}");
        enemyMaxHP = 100;
        enemyDamageBonus = 5;
        enemyAC = 12;
        enemyHP = enemyMaxHP;
        lootHeld = 7;
        enemyAccuracy = 1;
        Console.WriteLine($"Health: \t   {enemyHP}");
        Console.WriteLine("Another shiba? This isn't your territory, you nerd.");
        enemyMoves[0] = "Butt Slam"; enemyMoves[1] = "Chomp"; enemyMoves[2] = "Shiba Headbutt";
        break;
    case "C":
        enemyName = "Baboon";
        Console.WriteLine($"Opponent: \t {enemyName}");
        enemyMaxHP = 150;
        enemyDamageBonus = 10;
        enemyAC = 13;
        enemyHP = enemyMaxHP;
        lootHeld = 12;
        enemyAccuracy = 3;
        Console.WriteLine($"Health: \t   {enemyHP}");
        Console.WriteLine("Wait, why exactly is there a baboon here? No matter- an intruder is an intruder.");
        enemyMoves[0] = "Simian Slap"; enemyMoves[1] = "Monkey Kick"; enemyMoves[2] = "Baboon Bonk";
        break;
    default:
        Console.WriteLine("How?");
        break;
}

Console.WriteLine("");	
System.Threading.Thread.Sleep(2000);
Console.WriteLine("_____________________");

//Stat Increases
Console.WriteLine("Next, let's allocate some stats to Pup-Tart. Here's his stats:"); System.Threading.Thread.Sleep(1000);
Console.WriteLine("A) Vitality: \t Pup-Tart's health is equal to 10 x Vitality."); System.Threading.Thread.Sleep(500);
Console.WriteLine("B) Strength: \t Increases Pup-Tart's damage."); System.Threading.Thread.Sleep(500);
Console.WriteLine("C) Evasion: \t Decreases the likelihood of being hit by an attack. The opponent must roll this number or higher to hit you."); System.Threading.Thread.Sleep(500);
Console.WriteLine("D) Accuracy: \t Makes it easier for Pup-Tart to hit. This number is added to your attack rolls. \n"); System.Threading.Thread.Sleep(500);

Console.WriteLine("Each bonus will increase a stat by 3.");
int bonus = 3;

while (bonus > 0)
{
    Console.WriteLine($"Enter the letter of the stat you want to increase. {bonus} / 3 bonuses remaining.");
    string statIncrease = Console.ReadLine();
    while ((statIncrease.ToUpper() != "A") && (statIncrease.ToUpper() != "B") && (statIncrease.ToUpper() != "C") && (statIncrease.ToUpper() != "D"))
    {
        Console.WriteLine("That is not a valid stat. Try again.");
        statIncrease = Console.ReadLine();
    }
    switch (statIncrease.ToUpper())
    {
        case "A":
            shibaVitality += 3;
            bonus--;
            Console.WriteLine($"Vitality increased to {shibaVitality}. ");
            break;
        case "B":
            shibaStrength += 3;
            bonus--;
            Console.WriteLine($"Strength increased to {shibaStrength}.");
            break;
        case "C":
            shibaEvasion += 3;
            bonus--;
            Console.WriteLine($"Evasion increased to {shibaEvasion}.");
            break;
        case "D":
            shibaAccuracy += 3;
            bonus--;
            Console.WriteLine($"Accuracy increased to {shibaAccuracy}.");
            break;
        default:
            break;
    }
}
Console.WriteLine("_____________________");

//Final Stats
Console.WriteLine("Final Stats: ");
int shibaMaxHP = shibaVitality * 10;
int shibaHP = shibaMaxHP;
Console.WriteLine($"HP: \t \t {shibaHP} / {shibaMaxHP}");
Console.WriteLine($"Vitality: \t {shibaVitality}");
Console.WriteLine($"Strength: \t {shibaStrength}");
Console.WriteLine($"Evasion:  \t {shibaEvasion}");
Console.WriteLine($"Accuracy: \t {shibaAccuracy} \n");
Console.WriteLine("_____________________");
System.Threading.Thread.Sleep(1000);

//Rules Explanations
Console.WriteLine("SHIBA MOVES"); System.Threading.Thread.Sleep(1000);
Console.WriteLine($"{shibaMoves[0]}: \nDeals 1-10 damage, plus Strength. Regains 1 Energy on hit.\n"); System.Threading.Thread.Sleep(500);
Console.WriteLine($"{shibaMoves[1]}: \nDeals 10-20 damage, plus Strength. Receives a -3 penalty to Accuracy. Regains 2 Energy on hit.\n"); System.Threading.Thread.Sleep(500);
Console.WriteLine($"{shibaMoves[2]}: \nRestores 1-5 Energy.\n"); System.Threading.Thread.Sleep(500);
Console.WriteLine($"{shibaMoves[3]} [5 Energy]: \nIncreases Evasion by 5 for 2 rounds.\n"); System.Threading.Thread.Sleep(500);
Console.WriteLine($"{shibaMoves[4]} [8 Energy]: \nReduces enemy Evasion by 5 for 2 rounds.\n"); System.Threading.Thread.Sleep(500);
Console.WriteLine($"{shibaMoves[5]} [15 Energy]: \nGuaranteed hit, 30-50 damage plus Strength. Can inflict a critical hit.\n"); System.Threading.Thread.Sleep(500);
Console.WriteLine("");
Console.WriteLine("Energy is necessary for Zoomies and Judgment Stare. Be warned- if you try to use a move without sufficent energy, you'll waste your turn.");
Console.WriteLine("Rolling a 20 is a critical hit, doubling damage. \n");

Console.WriteLine("_____________________");
Console.WriteLine("\nPRESS ENTER WHEN YOU'RE READY TO PUNISH THE INFIDEL THAT INVADED YOUR DOMAIN.");
Console.ReadLine();

//Combat
while (shibaHP > 0 && enemyHP > 0)
{
    //Main Stat Display each Round
    Console.WriteLine("_____________________");
    Console.WriteLine($"Pup-Tart \tHP: {shibaHP} / {shibaMaxHP} \t Energy: {energy} \t Evasion: {shibaEvasion}");
    Console.WriteLine($"{enemyName} \t\tHP: {enemyHP} / {enemyMaxHP} \t Evasion: {enemyAC} \n");

    //Your Turn
    if (shibaHP > 0)
    {
        Console.WriteLine($"[A] {shibaMoves[0]} \t \t [B] {shibaMoves[1]} \t \t \t [C] {shibaMoves[2]}");
        Console.WriteLine($"[D] {shibaMoves[3]} (5 Energy) \t [E] {shibaMoves[4]} (8 Energy) \t [F] {shibaMoves[5]} (15 Energy)");
        Console.WriteLine("Choose your move: ");
        action = Console.ReadLine();

        //Action Verification; ensures you select a valid action
        while ((action.ToUpper() != "A") && (action.ToUpper() != "B") && (action.ToUpper() != "C") && (action.ToUpper() != "D") && (action.ToUpper() != "E") && (action.ToUpper() != "F") && (action.ToUpper() != "MEGAFLARE"))
        {
            Console.WriteLine("That is not a valid action. Try again.");
            action = Console.ReadLine();
        }
        switch (action.ToUpper())
        {
            case "A":   //Butt Slam
                Console.WriteLine($"\n{shibaMoves[0]}"); System.Threading.Thread.Sleep(500);
                attackRoll = diceRoll.Next(1, 21);
                total = attackRoll + shibaAccuracy;
                Console.WriteLine($"Roll: {attackRoll} + {shibaAccuracy} = {total}"); System.Threading.Thread.Sleep(500);
                if (total >= enemyAC)
                {

                    damage = damageRoll.Next(1, 11) + shibaStrength;
                    if (attackRoll == 20)
                    {
                        damage = damage * 2;
                        Console.Write("Critical ");
                    }
                    enemyHP -= damage;
                    energy += 1;
                    Console.Write($"Hit! {enemyName} takes {damage} damage!\n"); System.Threading.Thread.Sleep(500);
                    Console.WriteLine($"{enemyName} HP: \t {enemyHP} / {enemyMaxHP}"); System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Miss!\n"); System.Threading.Thread.Sleep(500);
                }
                break;
            case "B":   //Bite
                Console.WriteLine($"\n{shibaMoves[1]}"); System.Threading.Thread.Sleep(500);
                attackRoll = diceRoll.Next(1, 21);
                total = attackRoll + shibaAccuracy - 3;
                Console.WriteLine($"Roll: {attackRoll} + {shibaAccuracy} - 3 = {total}"); System.Threading.Thread.Sleep(500);
                if (total >= enemyAC)
                {
                    damage = damageRoll.Next(5, 21) + shibaStrength;
                    if (attackRoll == 20)
                    {
                        damage = damage * 2;
                        Console.WriteLine("Critical ");
                    }
                    enemyHP -= damage;
                    energy += 2;
                    Console.Write($"Hit! {enemyName} takes {damage} damage!\n"); System.Threading.Thread.Sleep(500);
                    Console.WriteLine($"{enemyName} HP: \t {enemyHP} / {enemyMaxHP}\n"); System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Miss! \n"); System.Threading.Thread.Sleep(500);
                }
                break;
            case "C":   //Shiba Scream
                Console.WriteLine($"\n{shibaMoves[2]}"); System.Threading.Thread.Sleep(500);
                damage = 0;     //Reuses damage because there's no reason not to; sets it to 0 to prevent previous damage from being counted.
                damage += damageRoll.Next(1, 6);
                Console.WriteLine($"Pup-Tart lets out a shiba scream and regains {damage} Energy!");
                energy += damage;
                break;
            case "D":   //Zoomies [5 Energy]
                Console.WriteLine($"\n{shibaMoves[3]}"); System.Threading.Thread.Sleep(500);
                if (energy >= 5) //Energy requirement met
                {
                    if (zoomiesTimer <= 0) //No current zoomies
                    {
                        zoomiesTimer = 2;
                        shibaEvasion += 5;
                        energy -= 5;
                        Console.WriteLine($"Pup-Tart has zoomies! Evasion is now {shibaEvasion}!"); System.Threading.Thread.Sleep(500);
                    }
                    else if (zoomiesTimer > 0) //Zoomies don't stack
                    {
                        Console.WriteLine("Pup-Tart already has zoomies! He has bamboozled himself!");
                    }
                }
                else //Not enough energy
                {
                    Console.WriteLine("Pup-Tart doesn't have the energy for that! He has bamboozled himself!");
                }
                break;
            case "E":   //Judgment Stare [8 Energy]
                Console.WriteLine($"\n{shibaMoves[4]}"); System.Threading.Thread.Sleep(500);
                if (energy >= 8) //Energy requirement met
                {
                    if (judgmentTimer <= 0) //No current judgment
                    {
                        judgmentTimer = 2;
                        enemyAC -= 5;
                        energy -= 5;
                        Console.WriteLine($"Pup-Tart stares at {enemyName} very judgmentally! {enemyName} feels intimidated and loses Evasion!"); System.Threading.Thread.Sleep(500);
                    }
                    else if (judgmentTimer > 0) //Judgment don't stack
                    {
                        Console.WriteLine($"{enemyName} already feels judged by Pup-Tart! Pup-Tart has bamboozled himself!");
                    }
                }
                else //Not enough energy
                {
                    Console.WriteLine("Pup-Tart doesn't have the energy for that! He has bamboozled himself!");
                }
                break;
            case "F":   //Suplex [15 Energy]
                Console.WriteLine($"\n{shibaMoves[5]}"); System.Threading.Thread.Sleep(500);
                if (energy >= 15) //Energy requirement met
                {
                    attackRoll = diceRoll.Next(1, 21);
                    damage = damageRoll.Next(30, 51) + shibaStrength;
                    if (attackRoll == 20)
                    {
                        damage = damage * 2;
                        Console.WriteLine("Critical Suplex!");
                    }
                    enemyHP -= damage;
                    energy -= 15;
                    Console.WriteLine($"Pup-Tart suplexes the {enemyName} for {damage} damage!"); System.Threading.Thread.Sleep(500);
                }
                else //Not enough energy
                {
                    Console.WriteLine("Pup-Tart doesn't have the energy for that! He has bamboozled himself!");
                }
                break;
            case "MEGAFLARE":   //Destroy everything
                Console.WriteLine($"\nPup-Tart breaks the laws of reality and casts Megaflare!"); System.Threading.Thread.Sleep(500);
                    enemyHP -= 9999;
                    Console.WriteLine($"{enemyName} takes 9999 damage from Pup-Tart's secret magical powers!"); System.Threading.Thread.Sleep(500);
                
                break;
        }
    }

     if (enemyHP > 0)
    {
        Console.WriteLine($"~~~{enemyName}'s Turn~~~");
        enemyAction = diceRoll.Next(1, 4);
        switch (enemyAction)
        {
            case 1:   //Quick Attack; Low Damage
                Console.WriteLine($"\n{enemyName} uses {enemyMoves[0]}!"); System.Threading.Thread.Sleep(500);
                attackRoll = diceRoll.Next(1, 21);
                total = attackRoll + enemyAccuracy + 5;
                Console.WriteLine($"Roll: {attackRoll} + {enemyAccuracy} (Accuracy) + 5 (Quick Attack) = {total}"); System.Threading.Thread.Sleep(500);
                if (total >= shibaEvasion)
                {

                    damage = damageRoll.Next(1, 5) + enemyDamageBonus;
                    if (attackRoll == 20)
                    {
                        damage = damage * 2;
                        Console.Write("Critical ");
                    }
                    shibaHP -= damage;
                    Console.Write($"Hit! Pup-Tart takes {damage} damage!\n"); System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Miss!\n"); System.Threading.Thread.Sleep(500);
                }
                break;
            case 2:   //Balanced Attack; Balanced Damage
                Console.WriteLine($"\n{enemyName} uses {enemyMoves[1]}!"); System.Threading.Thread.Sleep(500);
                attackRoll = diceRoll.Next(1, 21);
                total = attackRoll + enemyAccuracy;
                Console.WriteLine($"Roll: {attackRoll} + {enemyAccuracy} (Accuracy) = {total}"); System.Threading.Thread.Sleep(500);
                if (total >= shibaEvasion)
                {

                    damage = damageRoll.Next(5, 10) + enemyDamageBonus;
                    if (attackRoll == 20)
                    {
                        damage = damage * 2;
                        Console.Write("Critical ");
                    }
                    shibaHP -= damage;
                    Console.Write($"Hit! Pup-Tart takes {damage} damage!\n"); System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Miss!\n"); System.Threading.Thread.Sleep(500);
                }
                break;
            case 3:   //Heavy Attack; High Damage
                Console.WriteLine($"\n{enemyName} uses {enemyMoves[2]}!"); System.Threading.Thread.Sleep(500);
                attackRoll = diceRoll.Next(1, 21);
                total = attackRoll + enemyAccuracy - 5;
                Console.WriteLine($"Roll: {attackRoll} + {enemyAccuracy} (Accuracy) -5 (Heavy Attack) = {total}"); System.Threading.Thread.Sleep(500);
                if (total >= shibaEvasion)
                {

                    damage = damageRoll.Next(7, 20) + enemyDamageBonus;
                    if (attackRoll == 20)
                    {
                        damage = damage * 2;
                        Console.Write("Critical ");
                    }
                    shibaHP -= damage;
                    Console.Write($"Hit! Pup-Tart takes {damage} damage!\n"); System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Miss!\n"); System.Threading.Thread.Sleep(500);
                }
                break;
        }
    }

    //Status Check
    if (zoomiesTimer > 0)
    {
        zoomiesTimer--; 
    }
    else if (zoomiesTimer == 0)
    {
        shibaEvasion -= 5;
        zoomiesTimer = -1;
        Console.WriteLine("Pup-Tart's zoomies have worn off!"); 
    }

    if (judgmentTimer > 0)
    {
        judgmentTimer--;
    }
    else if (judgmentTimer == 0)
    {
        judgmentTimer = -1;
        enemyAC += 5;
        Console.WriteLine($"{enemyName} no longer feels judged by Pup-Tart!");
    }
}

//Combat Ends once someone's HP hits 0
if (enemyHP < 0)        //Enemy Defeat
{
    Console.WriteLine($"Pup-Tart has successfully repelled the invading {enemyName}!\n"); System.Threading.Thread.Sleep(2000);
    Console.WriteLine($"The {enemyName} left behind some loot...");
    for (int lootDrop = lootHeld; lootDrop > 0; lootDrop--)
    {
        Console.WriteLine(loot[diceRoll.Next(loot.Length)]);
    }
}
else if (shibaHP < 0)   //Pup-Tart Defeat
{
    Console.WriteLine($"Pup-Tart has had enough of these schenanigans. Unfortunately, the {enemyName} will have free reign of his territory and will probably eat his chicken nuggets. For shame.");
}


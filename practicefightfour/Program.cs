// See https://aka.ms/new-console-template for more information

/*void Initialize();
void AddItem( ItemType itemType, int Count);
void RemoveItem( ItemType itemType, int Count);
int CheckItemCount( ItemType itemType, int Count);
bool InventorySystem.CheckIfWeHaveItem( ItemType itemType, int Count);*/

// turnstart , playerson, playeresther, playerenemy, items, inventory, status, basestats
// status ;
// actions ; attack, skill, spells, guard, pray
// methods to each item class (perform action? different perform methods based on item type)
// devotion / blessing mechanic

// experience resets every level and requirement is switched for each level


using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.VisualBasic;

public class CharacterBaseStats
{

    public int Health { get; set; }
    //Math.Clamp(Health, 0, 100)
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Devotion { get; set; }

    public bool PanickingStatus { get; set; }
    public bool BleedingStatus { get; set; }
    public bool TiredStatus { get; set; }
    public bool ExhaustedStatus { get; set; }
    public bool FallenStatus { get; set; }


    public CharacterBaseStats(int health, int level, int experience, int attack, int defense, int devotion, bool panickingStatus, bool bleedingStatus, bool tiredStatus, bool exhaustedStatus, bool fallenStatus)
    {
        this.Health = health;
        this.Level = level;
        this.Experience = experience;
        this.Attack = attack;
        this.Defense = defense;
        this.Devotion = devotion;

        this.PanickingStatus = panickingStatus;
        this.BleedingStatus = bleedingStatus;
        this.TiredStatus = tiredStatus;
        this.ExhaustedStatus = exhaustedStatus;
        this.FallenStatus = fallenStatus;
    }
}
class SonPlayer
{
    public CharacterBaseStats SonStats = new CharacterBaseStats(100,1, 0, 5, 5, 0, false, false, false, false,false);
    public void AttackEnemy()
    {
       
    }
    public void CheckHealth() // makes sure health never goes above 100 or below 0
    {
        if (SonStats.Health < 0) {  SonStats.Health = 0; }
        if (SonStats.Health > 100) {  SonStats.Health = 100; }
    }


}

class SonActions
{

}

class EstherPlayer
{
    public CharacterBaseStats EstherStats = new CharacterBaseStats(80,1, 0, 5, 5, 0, false, false, false, false, false); // adjust this later pls
}

class EstherActions
{

}

class UniverseEnemy
{
    // create method for each type of attack / skill
    
    public CharacterBaseStats UniverseStats = new CharacterBaseStats(200,12, 0, 5, 5, 0, false, false, false, false, false);
    public UniverseEnemy(SonPlayer son, EstherPlayer esther)
    {
        this.son = son;
        this.esther = esther;
    }

    private CharacterBaseStats chosenTarget;
    private EstherPlayer esther = new EstherPlayer();
    private SonPlayer son = new SonPlayer();

    int chance;
    string targetname;

    public void ChooseAction()
    {
        Random RNG = new Random();
        if (RNG.Next(0, 3) == 0)
        {
            GazeSkill();
        }
        else if (RNG.Next(0, 3) == 1)
        {
            PassJudgementSkill();
        }
        else if (RNG.Next(0,3) == 2 && UniverseStats.Health < 200)
        {
            HealSkill();
        }
        else { ChooseAction(); }

    }
    
    public void CheckHealth() // makes sure health never goes above 100 or below 0
    {
        if (chosenTarget.Health < 0 || chosenTarget.Health == 0)
        {
            chosenTarget.Health = 0;
            chosenTarget.FallenStatus = true;
            Console.WriteLine($"{targetname} has fallen!");
        }
        if (chosenTarget.Health > 100) { chosenTarget.Health = 100; }
    }

    public void CheckFallen()
    {
        if (chosenTarget.FallenStatus == true) { ChooseTarget(); }
    }
    public void ChooseTarget()
    {
        Random RNG = new Random();
        

        if (RNG.Next(0, 2) == 0 && !son.SonStats.FallenStatus)
        {
            chosenTarget = son.SonStats;
            targetname = "Son";
        }
        else if (RNG.Next(0, 2) == 1 && !esther.EstherStats.FallenStatus)
        {
            chosenTarget = esther.EstherStats;
            targetname = "Esther";
        }
        else
        {
            chosenTarget = son.SonStats;
            targetname = "Son";
        }
    }

    public void HealSkill()
    {
        Console.WriteLine("The Universe answers a prayer.");
        UniverseStats.Health += 15;
        if ( UniverseStats.Health > 200 ) { UniverseStats.Health = 200;}
        Console.WriteLine($"The Universe regains 15 health! The Universe has {UniverseStats.Health} health left.");
    }

    public void RollChance()
    {
        Random RNG = new Random();
        chance = RNG.Next(0,101);
    }
    void GazeSkill() // Makes the targeted player panic.
    {
        // roll for which target, success, and for how many turns (1-3). if gaze is repeated then add on to the amount of turns
        Console.WriteLine("The Universe gazes...");
        ChooseTarget();
        RollChance();
        if (chance > 40)
        {
            chosenTarget.PanickingStatus = true;
            Console.WriteLine($"{targetname} is Panicking!");
        }
        else
        {
            Console.WriteLine("There was no effect!");
        }
    }

    void PassJudgementSkill()
    {
        Console.WriteLine("The Universe calls out..");
        ChooseTarget();
        RollChance();
        while (chosenTarget.FallenStatus == true) { ChooseTarget();}
        if (chance > 10)
        {
            chosenTarget.Health = chosenTarget.Health - 20;
            Console.WriteLine($"{targetname} takes 20 damage! {targetname} has {chosenTarget.Health} health left.");
            CheckHealth();
        }
        else
        {
            Console.WriteLine("The Universe misses!");
        }
    }
}

struct Inventory
{
    // half-eaten sandwich, pocket lint, bottle of water, dagger (weapon), staff (weapon), rope (restrain enemy? restrain status)
    //
}

class Program
{
    static void Main(string[] args)
    {
        
        SonPlayer son = new SonPlayer();
        EstherPlayer esther = new EstherPlayer();
        UniverseEnemy universe = new UniverseEnemy(son, esther);

        static void StartTurn(UniverseEnemy universe)
        {
            universe.ChooseAction();
            universe.UniverseStats.Health -= 15;
            Console.WriteLine($"The Universe loses 15 health. It has {universe.UniverseStats.Health} health remaining.");
        }

        while (esther.EstherStats.FallenStatus == false || son.SonStats.FallenStatus == false)
        {
            StartTurn(universe);
            // create method to check if health = 0
        }

        Console.WriteLine("The world fades...");
    }
}



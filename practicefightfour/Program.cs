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

public class CharacterBaseStats
{

    public int Health { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Devotion { get; set; }

    public bool PanickingStatus { get; set; }
    public bool BleedingStatus { get; set; }
    public bool TiredStatus { get; set; }
    public bool ExhaustedStatus { get; set; }


    public CharacterBaseStats(int health, int level, int experience, int attack, int defense, int devotion, bool panickingStatus, bool bleedingStatus, bool tiredStatus, bool exhaustedStatus)
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
    }
}
class SonPlayer
{
    public CharacterBaseStats SonStats = new CharacterBaseStats(100,1, 0, 5, 5, 0, false, false, false, false);
    public void AttackEnemy()
    {
       
    }


}

class SonActions
{

}

class EstherPlayer
{
    public CharacterBaseStats EstherStats = new CharacterBaseStats(80,1, 0, 5, 5, 0, false, false, false, false); // adjust this later pls
}

class EstherActions
{

}

class UniverseEnemy
{
    // create method for each type of attack / skill
    
    public CharacterBaseStats UniverseStats = new CharacterBaseStats(200,12, 0, 5, 5, 0, false, false, false, false);
    CharacterBaseStats chosenTarget;
    EstherPlayer esther = new EstherPlayer();
    SonPlayer son = new SonPlayer();

    int chance;
    string targetname;
    public void ChooseTarget()
    {
        Random RNG = new Random();
        

        if (RNG.Next(0, 2) == 0)
        {
            chosenTarget = son.SonStats;
            targetname = "Son";
        }
        else
        {
            chosenTarget = esther.EstherStats;
            targetname = "Esther";
        }
    }

    public void RollChance()
    {
        Random RNG = new Random();
        chance = RNG.Next(0,101);
    }
    public void GazeSkill() // Makes the targeted player panic.
    {
        // roll for which target, success, and for how many turns (1-3). if gaze is repeated then add on to the amount of turns
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

    public void PassJudgementSkill()
    {
        ChooseTarget();
        RollChance();
        if (chance > 20)
        {
            chosenTarget.Health = chosenTarget.Health - 20;
            Console.WriteLine($"{targetname} takes 20 damage! {targetname} has {chosenTarget.Health} health left.");
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
        UniverseEnemy universe = new UniverseEnemy();
        //SonPlayer son = new SonPlayer();
        //CharacterBaseStats chosenTarget;

        universe.PassJudgementSkill();
        universe.PassJudgementSkill();
        universe.PassJudgementSkill();
        universe.PassJudgementSkill();
        universe.PassJudgementSkill();
        universe.PassJudgementSkill();
    }
}
class TurnStart
{
    // method check if status true <-- create for each actor
    // method check end of battle if experience reaches requirement to level up
}


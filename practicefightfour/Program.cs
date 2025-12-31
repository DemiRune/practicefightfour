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


using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class CharacterBaseStats
{
    
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Devotion { get; set; }

    public CharacterBaseStats(int level, int experience, int attack, int defense, int devotion)
    {
        this.Level = level;
        this.Experience = experience;
        this.Attack = attack;
        this.Defense = defense;
        this.Devotion = devotion;
    }
}
class SonPlayer
{
    public CharacterBaseStats SonStats = new CharacterBaseStats(1, 0, 5, 5, 0);
    public void AttackEnemy()
    {
       
    }


}

class SonActions
{

}

class EstherPlayer
{

}

class EstherActions
{

}

class UniverseEnemy
{

}

// create new instance of each status for every actor
class PanickingStatus // Chances to miss or not attack drastically raise, crits are a 0
{
   
}

class RestrainedStatus // All actions fail. Take damage on each turn
{

}

class BleedingStatus // Take damage on each turn. If untreated, adds Tired status, then develops into Exhausted.
{

}

class TiredStatus // Slight drop on all stats. Praying grants less devotion.
{

}

class ExhaustedStatus // Drastic drop on all stats. High chance to miss or will straight up not attack and spells may not work. Takes more damage.
{

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

    }
}
class TurnStart
{
    // method check if status true <-- create for each actor
    // method check end of battle if experience reaches requirement to level up
}


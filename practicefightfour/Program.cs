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

class SonPlayer
{
    public int Health { get; set; }
    public int Defense { get; set; }

}

class EstherPlayer
{

}

class UniverseEnemy
{

}

// create new instance of each status for every actor
class PanickingStatus // Chances to miss or not attack drastically raise, crits are a 0
{
   
}

class RestrainedStatus // Unability to use action besides
{

}

class BleedingStatus
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
}


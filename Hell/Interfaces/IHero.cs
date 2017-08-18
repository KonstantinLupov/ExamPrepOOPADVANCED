using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IHero
{
    IInventory inventory { get; } 
    ICollection<IItem> Items { get; }
    string Name { get; }
    long Strength { get; }
    long Agility { get; }
    long Intelligence { get; }
    long HitPoints { get; }
    long Damage { get; }
}
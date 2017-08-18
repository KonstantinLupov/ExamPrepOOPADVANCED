using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Assassin : AbstractHero
{
    public Assassin(string name) : base(name)
    {
        this.Strength = 25;
        this.Agility = 100;
        this.Intelligence = 15;
        this.HitPoints = 150;
        this.Damage = 300;
    }
}
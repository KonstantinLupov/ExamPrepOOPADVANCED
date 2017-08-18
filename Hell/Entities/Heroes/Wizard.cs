using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Wizard : AbstractHero
{
    public Wizard(string name) : base(name)
    {
        this.Strength = 25;
        this.Agility = 25;
        this.Intelligence = 100;
        this.HitPoints = 100;
        this.Damage = 250;
    }
}
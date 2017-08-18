using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    public IInventory inventory { get; set; }
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;
    private string name;

    protected AbstractHero(string name)
    {
        this.Name = name;
        this.Inventory = new HeroInventory();
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
        set { this.inventory = value; }
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public long Strength
    {
        get { return this.strength + this.Inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.Inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.Inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.Inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.Inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);

            Dictionary<string, IItem> dic = (Dictionary <string, IItem>)field.GetValue(this.Inventory);

            return dic.Values;
        }
    }

    public void AddRecipe(RecipeItem recipeItem)
    {
        this.Inventory.AddRecipeItem(recipeItem);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hero: {Name}, Class: {this.GetType().Name}");
        sb.AppendLine($"HitPoints: {HitPoints}, Damage: {Damage}");
        sb.AppendLine($"Strength: {Strength}");
        sb.AppendLine($"Agility: {Agility}");
        sb.AppendLine($"Intelligence: {Intelligence}");


        if (Items.Count != 0)
        {
            sb.AppendLine($"Items:");
            foreach (Item item in Items)
            {
                sb.AppendLine(item.ToString());
            }
        }
        else
        {
            sb.AppendLine($"Items: None");
        }
        return sb.ToString().Trim();
    }
}
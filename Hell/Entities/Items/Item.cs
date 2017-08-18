using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Item : IItem
{
    public Item(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus,
        long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get; set; }
    public long StrengthBonus { get; set; }
    public long AgilityBonus { get; set; }
    public long IntelligenceBonus { get; set; }
    public long HitPointsBonus { get; set; }
    public long DamageBonus { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"###Item: {Name}");
        sb.AppendLine($"###+{StrengthBonus} Strength");
        sb.AppendLine($"###+{AgilityBonus} Agility");
        sb.AppendLine($"###+{IntelligenceBonus} Intelligence");
        sb.AppendLine($"###+{HitPointsBonus} HitPoints");
        sb.AppendLine($"###+{DamageBonus} Damage");

        return sb.ToString().Trim();
    }
}
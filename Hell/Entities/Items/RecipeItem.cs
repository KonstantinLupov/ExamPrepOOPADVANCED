using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RecipeItem : Item, IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, List<string> requiredItems) : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = requiredItems;
    }

    public List<string> RequiredItems { get; set; }
    
}
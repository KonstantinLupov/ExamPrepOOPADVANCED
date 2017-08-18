using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IInventory
{
    long TotalStrengthBonus { get; }
    long TotalAgilityBonus { get; }
    long TotalIntelligenceBonus { get; }
    long TotalHitPointsBonus { get; }
    long TotalDamageBonus { get; }
    void AddCommonItem(IItem item);
    void AddRecipeItem(IRecipe recipe);
}
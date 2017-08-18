using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(List<String> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero) constructors[0].Invoke(new object[] {heroName});

            this.heroes.Add(hero.Name, hero);
            result = string.Format($"Created {heroType} - {hero.Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(List<string> arguments)
    {
        string result = null;

        //Ма те много бе!
        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);

        IHero hero = heroes[heroName];

        hero.inventory.AddCommonItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeToHero(List<string> arguments)
    {
        string result = null;

        //Ма те много бе!
        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);
        List<string> requiredItems = new List<string>();

        int i = 7;
        foreach (var item in arguments.Skip(7).ToList())
        {
            string requiredItem = heroes[heroName].Items.FirstOrDefault(x => x.Name == item).Name;
            if (requiredItem != null)
            {
            requiredItems.Add(requiredItem);
            }
            else 
            {
                requiredItems.Add(arguments[i]);
            }
            i++;
        }
        RecipeItem newItem = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus, requiredItems);

        IHero hero = heroes[heroName];
        hero.inventory.AddRecipeItem(newItem);


        result = string.Format(Constants.RecipeCreatedMessage, newItem.Name, heroName);
        return result;
    }

    public string Quit(List<string> argsList)
    {
        StringBuilder sb = new StringBuilder();
        int i = 1;
        foreach (IHero hero in heroes.Values.OrderByDescending(x => x.Strength + x.Agility + x. Intelligence).ThenByDescending(x => x.HitPoints + x.Damage))
        {
            List<string> items = new List<string>();

            foreach (IItem item in hero.Items)
            {
                items.Add(item.Name);
            }
            sb.AppendLine($"{i}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");
            if (items.Count != 0)
            {
                sb.AppendLine($"###Items: {string.Join(", ", items)}");
            }
            else
            {
                sb.AppendLine($"###Items: None");
            }
            i++;
        }
        return sb.ToString().Trim();
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }
}
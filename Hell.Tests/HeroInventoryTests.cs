using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Tests
{
    [TestFixture]
    public class HeroInventoryTests
    {
        private IInventory inventory;
        [SetUp]
        public void Start()
        {
            inventory = new HeroInventory();
        }

        [Test]
        public void AddCommonItem_Adds_Item_With_Its_Name()
        {
            //Arrange
            IItem item = new CommonItem("a",10,10,10,10,10);

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);

            Dictionary<string, IItem> dic = (Dictionary<string, IItem>)field.GetValue(inventory);

            //Act
            inventory.AddCommonItem(item);

            //Assert
            Assert.AreEqual(dic["a"], item);
        }
        [Test]
        public void AddRecipeItem_Adds_Item_With_Its_Name()
        {
            //Arrange
            IRecipe item = new RecipeItem("a", 10, 10, 10, 10, 10, new List<string>());

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "recipeItems");

            Dictionary<string, IRecipe> dic = (Dictionary<string, IRecipe>)field.GetValue(inventory);

            //Act
            inventory.AddRecipeItem(item);

            //Assert
            Assert.AreEqual(dic["a"], item);
        }

        [Test]
        public void TotalStrengthBonus_Equals_Its_Expected_Value()
        {
            //Arrange
            long expectedValue = inventory.TotalStrengthBonus;
            //Act

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);

            Dictionary<string, IItem> dic = (Dictionary<string, IItem>)field.GetValue(inventory);


            //Assert
            Assert.AreEqual(expectedValue,dic.Values.Sum(x => (long)x.StrengthBonus));
        }
    }
}

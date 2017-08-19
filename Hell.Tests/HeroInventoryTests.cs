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
        public void AddCommonItem()
        {
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

            inventory.AddCommonItem(item);

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);

            var dic = (Dictionary<string, IItem>) field.GetValue(inventory);

            Assert.AreEqual(1, dic.Count);
        }
        [Test]
        public void AddCommonItemMore()
        {
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
            CommonItem item1 = new CommonItem("item1", 11, 12, 13, 14, 51);

            inventory.AddCommonItem(item);
            inventory.AddCommonItem(item1);

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);

            var dic = (Dictionary<string, IItem>)field.GetValue(inventory);

            Assert.AreEqual(2, dic.Count);
        }

        [Test]
        public void AddRecipeItem()
        {
            RecipeItem item = new RecipeItem("item", 1, 2, 3, 4, 5, new List<string>());

            inventory.AddRecipeItem(item);

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);


            var dic = (Dictionary<string, IRecipe>) field.GetValue(inventory);

            Assert.AreEqual(1, dic.Count);
        }
        [Test]
        public void AddRecipeItemMore()
        {
            RecipeItem item = new RecipeItem("item", 1, 2, 3, 4, 5, new List<string>(){"a"});
            RecipeItem item1 = new RecipeItem("item1", 11, 12, 13, 14, 15, new List<string>(){"b"});


            inventory.AddRecipeItem(item);
            inventory.AddRecipeItem(item1);


            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);


            var dic = (Dictionary<string, IRecipe>)field.GetValue(inventory);

            Assert.AreEqual(2, dic.Count);
        }

        [Test]
        public void AddCommonItemsRecipeCreated()
        {
            CommonItem c1 = new CommonItem("c1", 10, 10, 10, 10, 10);
            CommonItem c2 = new CommonItem("c2", 15, 15, 15, 15, 15);
            RecipeItem r1 = new RecipeItem("r1", 25, 25, 25, 25 ,25, new List<string>(){"c1","c2"});

            inventory.AddCommonItem(c1);
            inventory.AddCommonItem(c2);
            inventory.AddRecipeItem(r1);

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);
            FieldInfo field1 = type.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);
               
            var dic = (Dictionary<string, IItem>)field.GetValue(inventory);
            var dic1 = (Dictionary<string, IRecipe>) field1.GetValue(inventory);
            Assert.AreEqual(1, dic.Count);
            Assert.AreEqual(1, dic1.Count);
        }
        [Test]
        public void AddRecipeThenCommonItems()
        {
            RecipeItem r1 = new RecipeItem("r1", 25, 25, 25, 25, 25, new List<string>() { "c1", "c2" });
            CommonItem c1 = new CommonItem("c1", 10, 10, 10, 10, 10);
            CommonItem c2 = new CommonItem("c2", 15, 15, 15, 15, 15);

            inventory.AddRecipeItem(r1);
            inventory.AddCommonItem(c1);
            inventory.AddCommonItem(c2);

            Type type = typeof(HeroInventory);
            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute)).Count() == 1);
            FieldInfo field1 = type.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);

            var dic = (Dictionary<string, IItem>)field.GetValue(inventory);
            var dic1 = (Dictionary<string, IRecipe>)field1.GetValue(inventory);
            Assert.AreEqual(1, dic.Count);
            Assert.AreEqual(1, dic1.Count);
        }
        [Test]
        public void AddCommonItem_ExpectedTotalStrengthBonus()
        {
            //Arrange
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

            //Act
            inventory.AddCommonItem(item);

            //Assert
            Assert.AreEqual(1, inventory.TotalStrengthBonus);
        }

        [Test]
        public void AddCommonItem_ExpectedTotalIntelligenceBonus()
        {
            //Arrange
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

            //Act
            inventory.AddCommonItem(item);

            //Assert
            Assert.AreEqual(3, inventory.TotalIntelligenceBonus);
        }

        [Test]
        public void AddCommonItem_ExpectedTotalAgilityBonus()
        {
            //Arrange
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

            //Act
            inventory.AddCommonItem(item);


            //Assert
            Assert.AreEqual(2, inventory.TotalAgilityBonus);
        }

        [Test]
        public void AddCommonItem_ExpectedTotalDamageBonus()
        {
            //Arrange
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

            //Act
            inventory.AddCommonItem(item);

            //Assert
            Assert.AreEqual(5, inventory.TotalDamageBonus);
        }

        [Test]
        public void AddCommonItem_ExpectedTotalHitPointsBonus()
        {
            //Arrange
            CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

            //Act
            inventory.AddCommonItem(item);


            //Assert
            Assert.AreEqual(4, inventory.TotalHitPointsBonus);
        }
    }
}
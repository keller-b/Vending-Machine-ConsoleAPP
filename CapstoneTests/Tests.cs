using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ChipsConstructor()
        {
            Chips test = new Chips("Potato Crisps", 3.05m);
            Assert.AreEqual("Potato Crisps", test.Name);
            Assert.AreEqual(3.05m, test.Price);
        }
        [TestMethod]
        public void CandyConstructor()
        {
            Candy test = new Candy("Mars Bar", 1.05m);
            Assert.AreEqual("Mars Bar", test.Name);
            Assert.AreEqual(1.05m, test.Price);
        }
        [TestMethod]
        public void DrinkConstructor()
        {
            Drink test = new Drink("Sad Juice", 6.05m);
            Assert.AreEqual("Sad Juice", test.Name);
            Assert.AreEqual(6.05m, test.Price);
        }
        [TestMethod]
        public void GumConstructor()
        {
            Gum test = new Gum("Bigly", 0.15m);
            Assert.AreEqual("Bigly", test.Name);
            Assert.AreEqual(0.15m, test.Price);
        }
        [TestMethod]
        public void VMConstructor()
        {
            VM test = new VM();
            Assert.AreEqual(16, test.Inventory.Count);
            Assert.AreEqual(true, test.Inventory.ContainsKey("B3"));
            Assert.AreEqual(true, test.Inventory.ContainsKey("D4"));
            Assert.AreEqual("Potato Crisps", test.Inventory["A1"].Name);
            Assert.AreEqual(1.75m, test.Inventory["B4"].Price);
        }
        [TestMethod]
        public void VMAddMoneyAndCheckBalance()
        {
            VM test = new VM();
            test.AddMoney(2.34m);
            Assert.AreEqual(2.34m, test.Balance);
            test.AddMoney(2.00m);
            Assert.AreEqual(4.34m, test.Balance);
            test.AddMoney(.05m);
            Assert.AreEqual(4.39m, test.Balance);
        }
        [TestMethod]
        public void VMDispenseChange()  //only numbers divisible by .05 are tested because we validate money fed to be whole dollar amounts and all item prices are divisible by .05
        {
            VM test = new VM();
            UI testUI = new UI();
            test.AddMoney(5.00m);
            Assert.AreEqual("\nDispensing change: 20 Quarters 0 Dimes 0 Nickles ", test.DispenseChange());
            test.AddMoney(12.00m);
            Assert.AreEqual("\nDispensing change: 48 Quarters 0 Dimes 0 Nickles ", test.DispenseChange());
            test.AddMoney(12.35m);
            Assert.AreEqual("\nDispensing change: 49 Quarters 1 Dimes 0 Nickles ", test.DispenseChange());
            test.AddMoney(0.05m);
            Assert.AreEqual("\nDispensing change: 0 Quarters 0 Dimes 1 Nickles ", test.DispenseChange());
        }
        [TestMethod]
        public void ItemSold()
        {
            Chips test = new Chips("Crispy Bits", 1.50m);
            test.Sold++;
            Assert.AreEqual(1, test.Sold);
            test.Sold++; test.Sold++;
            Assert.AreEqual(3, test.Sold);
        }
        [TestMethod]
        public void ItemQT()
        {
            Gum test = new Gum("Mouth Puddy", 2.30m);
            Assert.AreEqual(5, test.Quantity);
            test.Quantity--;
            Assert.AreEqual(4, test.Quantity);
            test.Quantity--;
            Assert.AreEqual(3, test.Quantity);
        }
        [TestMethod]
        public void ItemPrice()
        {
            Drink test = new Drink("Sludge", 1.40m);
            Assert.AreEqual(1.40m, test.Price);
            test = new Drink("Slime", 1.75m);
            Assert.AreEqual(1.75m, test.Price);
        }
        [TestMethod]
        public void ItemName()
        {
            Candy test = new Candy("Glue", 3.00m);
            Assert.AreEqual("Glue", test.Name);
            test = new Candy("Toothpaste", 1.20m);
            Assert.AreEqual("Toothpaste", test.Name);
        }
        [TestMethod]
        public void UIValidInput()
        {
            UI test = new UI();
            
        }
    }
}

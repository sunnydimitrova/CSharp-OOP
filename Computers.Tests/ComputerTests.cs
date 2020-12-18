namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Computer comp;
        private Part part;
        private Part part2;

        [SetUp]
        public void Setup()
        {
            part = new Part("Mouse", 10);
            part2 = new Part("Board", 20);
            comp = new Computer("Asus");
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        public void NameShoudThrowException(string name)            
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void SetNameIfWorks()
        {
            Assert.AreEqual("Asus", comp.Name);
        }

        [Test]
        public void TestIfListWorks()
        {
            comp.AddPart(part);
            comp.AddPart(part2);
            Assert.AreEqual(2, comp.Parts.Count);
        }

        [Test]
        public void TestToalPrice()
        {
            comp.AddPart(part);
            comp.AddPart(part2);
            Assert.AreEqual(30, comp.TotalPrice);
        }

        [Test]
        public void AddShoudThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() => comp.AddPart(null));
        }

        [Test]
        public void CountMustDecreaseAfterRemove()
        {
            comp.AddPart(part);
            comp.RemovePart(part);
            Assert.AreEqual(0, comp.Parts.Count);
        }

        [Test]
        public void TestGetPart()
        {
            comp.AddPart(part);
            comp.AddPart(part2);
            var actual = comp.GetPart("Mouse");
            Assert.AreEqual(part, actual);
        }
    }
}
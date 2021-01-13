using NUnit.Framework;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.ComTypes;
using VendingMachineKata;
using VendingMachineKata.BeforeStatePattern;

namespace VendingMachineKataTests.BeforeStatePattern
{
    [TestFixture()]
    public class VendingMachineTests
    {

        [Test()]
        public void Cancel_WhenCalledAfterAddingNoCash_ReturnsZero()
        {
            var sut = CreateSut();

            Assert.That(sut.Cancel(), Is.EqualTo(0));
        }

        [TestCase(new double[] { 5 }, 5)]
        [TestCase(new double[] { 5 , 10}, 15)]
        [TestCase(new double[] { 5 , 10, 20, 20}, 55)]
        public void Cancel_WhenCalledAfterAddingSomeCash_ReturnsAllCashAdded(double[] cashToAdd, double expectedResult)
        {
            var sut = CreateSut();
            foreach (var cash in cashToAdd)
            {
                sut.AddCash(cash);
            }
            Assert.That(sut.Cancel(), Is.EqualTo(expectedResult));
        }

        [Test()]
        public void Cancel_WhenCalledMultipleTimes_OnlyReturnsCashOnce()
        {
            var sut = CreateSut();
            sut.AddCash(10);
            sut.AddCash(50);

            Assert.That(sut.Cancel(), Is.EqualTo(60));
            Assert.That(sut.Cancel(), Is.EqualTo(0));
        }

        [Test()]
        public void AddCash_WhenCalled_AddsSomeCash()
        {
            //hard to check this actually adds some cash but we can check that we cancel and get some money bac
            var sut = CreateSut();
            sut.AddCash(100);
            Assert.That(sut.Cancel(), Is.EqualTo(100));
        }

        [Test()]
        public void AddCash_WhenCalledAfterCancel_StillAddsCash()
        {
            var sut = CreateSut();
            sut.AddCash(100);
            sut.Cancel();
            
            //now we can add some more cash and make sure that works
            sut.AddCash(200);
            Assert.That(sut.Cancel(), Is.EqualTo(200));

        }

        [Test()]
        public void Dispense_WhenMachineIsEmpty_ReturnsUnableToVendResult()
        {
            var sut = CreateSut();

            var vend = sut.Dispense();

            Assert.That(vend.VendResult, Is.EqualTo(VendResult.UnableToVend));
            Assert.That(vend.Change, Is.EqualTo(0));
        }

        [Test()]
        public void Dispense_WhenSomeCashIsAddedButNotEnough_ReturnsUnableToVendResult()
        {
            var sut = CreateSut();
            sut.AddCash(20);
            sut.AddCash(10);
            sut.AddCash(5);
            sut.AddCash(2);
            sut.AddCash(2);

            var vend = sut.Dispense();

            Assert.That(vend.VendResult, Is.EqualTo(VendResult.UnableToVend));
            Assert.That(vend.Change, Is.EqualTo(0));
        }

        [Test()]
        public void Dispense_WhenExactCashIsAdded_ReturnsSuccesfulVendResultButNoChange()
        {
            var sut = CreateSut();
            sut.AddCash(20);
            sut.AddCash(20);

            var vend = sut.Dispense();

            Assert.That(vend.VendResult, Is.EqualTo(VendResult.SuccessfulVend));
            Assert.That(vend.Change, Is.EqualTo(0));
        }

        [Test()]
        public void Dispense_WhenTooMuchCashIsAdded_ReturnsSuccessfulResultAndCorrectChange()
        {
            var sut = CreateSut();
            sut.AddCash(50);

            var vend = sut.Dispense();

            Assert.That(vend.VendResult, Is.EqualTo(VendResult.SuccessfulVend));
            Assert.That(vend.Change, Is.EqualTo(10));
        }

        [TestCase(new double[] { 20, 20 })]
        [TestCase(new double[] { 50 })]
        public void Dispense_WhenCalledAfterASucessfulVend_ReturnsUnableToVendResult(double[] cashToAdd)
        {
            var sut = CreateSut();
            foreach(var cash in cashToAdd)
            {
                sut.AddCash(cash);
            }

            var vendResult1 = sut.Dispense();
            var vendResult2 = sut.Dispense();

            Assert.That(vendResult1.VendResult, Is.EqualTo(VendResult.SuccessfulVend));
            Assert.That(vendResult2.VendResult, Is.EqualTo(VendResult.UnableToVend));
        }

        [TestCase(new double[] { 20, 20 })]
        [TestCase(new double[] { 50 })]
        public void Cancel_WhenCalledAfterASucessfulVend_ReturnsNoCash(double[] cashToAdd)
        {
            var sut = CreateSut();
            foreach (var cash in cashToAdd)
            {
                sut.AddCash(cash);
            }

            Assert.That(sut.Dispense().VendResult, Is.EqualTo(VendResult.SuccessfulVend));
            Assert.That(sut.Cancel(), Is.EqualTo(0));
        }

        private VendingMachineKata.BeforeStatePattern.VendingMachine CreateSut()
        {
            return new VendingMachineKata.BeforeStatePattern.VendingMachine();
        }

    }
}
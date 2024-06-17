using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopDiscount.Tests
{
    [TestFixture]
    public class DiscountTest
    {
        public EmployeeDiscount _discount { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            _discount = new EmployeeDiscount();
        }

        // Test 1
        // This test case is to check be sure that we get the same price when we choose part time as employee type
        [Test]
        public void TestPartTime_ValidValue()
        {
            // Arrange
            var type = EmployeeType.PartTime;
            var price = 49;

            // Act
            _discount.EmployeeType = type;
            _discount.Price = price;
            _discount.Price = _discount.CalculateDiscountedPrice();

            // Assert
            Assert.That(_discount.Price, Is.EqualTo(49));
        }

        // Test 2
        // This test case is to ensure the actual answer for a zero price is 0 irregardless of discount type
        [Test]
        public void TestPartialLoad_ZeroValue()
        {
            // Arrange
            var type = EmployeeType.PartialLoad;
            var price = 0;

            // Act
            _discount.EmployeeType = type;
            _discount.Price = price;
            _discount.Price = _discount.CalculateDiscountedPrice();

            // Assert
            Assert.That(_discount.Price, Is.EqualTo(0));
        }

        // Test 3
        // This test case is to ensure the actual answer for a negative price is negative irregardless of discount type
        [Test]
        public void TestFullTime_NegativeValue()
        {
            // Arrange
            var type = EmployeeType.FullTime;
            var price = -3;

            // Act
            _discount.EmployeeType = type;
            _discount.Price = price;
            _discount.Price = _discount.CalculateDiscountedPrice();

            // Assert
            Assert.That(_discount.Price, Is.EqualTo(-2.7));
        }

        // Test 4
        // This test case is to ensure the actual answer for a very large price
        [Test]
        public void TestCompanyPurchasing_HighValue()
        {
            // Arrange
            var type = EmployeeType.CompanyPurchasing;
            var price = 1000000;

            // Act
            _discount.EmployeeType = type;
            _discount.Price = price;
            _discount.Price = _discount.CalculateDiscountedPrice();

            // Assert
            Assert.That(_discount.Price, Is.EqualTo(800000));
        }

        // Test 5
        // This test case is for a postive value with fulltime discount
        [Test]
        public void TestFullTime_PositiveValue()
        {
            // Arrange
            var type = EmployeeType.FullTime;
            var price = 10;

            // Act
            _discount.EmployeeType = type;
            _discount.Price = price;
            _discount.Price = _discount.CalculateDiscountedPrice();

            // Assert
            Assert.That(_discount.Price, Is.EqualTo(9));
        }

        // Test 6
        // This test case is for a negative value with no discount
        [Test]
        public void TestPartTime_NegativeValue()
        {
            // Arrange
            var type = EmployeeType.PartTime;
            var price = -10;

            // Act
            _discount.EmployeeType = type;
            _discount.Price = price;
            _discount.Price = _discount.CalculateDiscountedPrice();

            // Assert
            Assert.That(_discount.Price, Is.EqualTo(-10));
        }



    }
}
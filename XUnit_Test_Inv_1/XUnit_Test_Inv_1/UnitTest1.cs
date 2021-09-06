using Inv_1;
using System;
using Xunit;

namespace XUnit_Test_Inv_1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true, "jjulian.341@gmail.com")]
        [InlineData(false, "braalfa.com")]
        [InlineData(false, "@braalfa.com")]
        public void validateEmails(bool expected, string email)
        {
            var emp = new Employee();

            bool isValid = emp.isValidEmail(email);

            Assert.Equal(expected, isValid);
        }

        [Theory]
        [InlineData(5250, 5000, 5)]
        [InlineData(108, 100, 8)]
        public void validateSalaryIncrement(int expected, int currentSalary, int incrementPorcentage)
        {
            var emp = new Employee();

            int newSalary = emp.calculateSalaryIncrement(currentSalary, incrementPorcentage);

            Assert.Equal(expected, newSalary);
        }

        [Fact]
        public void throwExceptionEmailNull()
        {
            var emp = new Employee();

            Assert.Throws<Exception>(() => emp.isValidEmail(null));
        }


    }
}

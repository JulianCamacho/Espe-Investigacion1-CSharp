using Inv_1;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace XUnit_Test_Inv_1
{
    public class UnitTest1
    {

        /// <summary>
        /// Función de prueba verificar si un email es validado correctamente
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="email"></param>
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


        /// <summary>
        /// Función de prueba para verificar si se calcula el nuevo salario correctamente
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="currentSalary"></param>
        /// <param name="incrementPorcentage"></param>
        [Theory]
        [InlineData(5250, 5000, 5)]
        [InlineData(108, 100, 8)]
        public void validateSalaryIncrement(int expected, int currentSalary, int incrementPorcentage)
        {
            var emp = new Employee();

            int newSalary = emp.calculateSalaryIncrement(currentSalary, incrementPorcentage);

            Assert.Equal(expected, newSalary);
        }


        /// <summary>
        /// Función de prueba para verificar si se genera una excepción 
        /// si no se proporciona un email
        /// </summary>
        [Fact]
        public void throwExceptionEmailNull()
        {
            var emp = new Employee();

            Assert.Throws<Exception>(() => emp.isValidEmail(null));
        }

        /// <summary>
        /// Función para verificar que se obtiene el empleado correcto de una lista
        /// </summary>
        [Fact]
        public void validateGetUserFromList()
        {
            //Arrange
            Employee[] employees = new Employee[3] {
                new Employee { name = "José", email = "aaaa@aaaa.com", salary = 700 },
                new Employee { name = "María", email = "bbbb@bbbb.com", salary = 1500 },
                new Employee { name = "Isabel", email = "cccc@cccc.com", salary = 650 }
            };

            int index = 2;
            Employee expected = employees[2];

            //Act
            Employee actual = EmployeeDataBase.getEmployeeAt(employees, index);

            //Assert
            Assert.NotEmpty(employees);
            Assert.IsType<Employee>(actual);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Función de prueba para verificar que un email
        /// corresponde a un correo institucional
        /// </summary>
        /// <param name="email"></param>
        [Theory]
        //[InlineData("jjulian.341@gmail.com")] //No pasa la prueba
        [InlineData("jcamacho@estudiantec.cr")]
        [InlineData("braalfa@estudiantec.cr")]
        public void validateCompanyEmails(string email)
        {
            //Arrange
            var emp = new Employee();

            //Act
            bool isCompanyEmail = emp.checkCompanyEmail(email);

            //Assert
            Assert.EndsWith("estudiantec.cr", email);
            Assert.True(isCompanyEmail);
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace Inv_1
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    public class Employee
    {
        public string name { get; set; }
        public string email { get; set; }
        public int salary { get; set; }

        /// <summary>
        /// Función para determinar si una dirección de email es válido o no
        /// </summary>
        /// <param name="email"> Dirección de email por validar </param>
        /// <returns></returns>
        public bool isValidEmail(string email)
        {

            //Si no se proporciona un email generar una nueva excepción
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception();
            }

            //Expresión regular válida para un email
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            //Retornar el resultado d el email proporcionado es válido
            return regex.IsMatch(email);
        }

        /// <summary>
        /// Función para calcular el nuevo salario de un empleado
        /// </summary>
        /// <param name="currentSalary"> Salario actual del empleado </param>
        /// <param name="incrementPorcentage"> Porcentaje del salario por incrementar </param>
        /// <returns> Nuevo salario del empleado </returns>
        public int calculateSalaryIncrement(int currentSalary, int incrementPorcentage) 
        {
            int newSalary = currentSalary + (currentSalary*incrementPorcentage/100);
            return newSalary;
        }


        /// <summary>
        /// Función para verificar si un email es de una compañía
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool checkCompanyEmail(string email)
        {
            return email.EndsWith("@estudiantec.cr");
        }

    }

    public class EmployeeDataBase {


        /// <summary>
        /// Función para obtener el empleado en la posición proporcionada
        /// </summary>
        /// <param name="employees"> Lista de todos los empleados </param>
        /// <param name="index"> Posición en la lista por retornar </param>
        /// <returns> El empleado en la posición requerida </returns>
        public static Employee getEmployeeAt(Employee[] employees, int index) {

            return employees[index];
        }
    }
}

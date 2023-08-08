using A_24Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace binary_and_xml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Id = 101,
                FirstName = "Dhana",
                LastName = "Lakshmi",
                Salary = 72000.0
            };


            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("C:\\AUG5\\A-24Lib\\employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, employee);
            }


            Employee deserializedEmployee;
            using (FileStream fileStream = new FileStream("C:\\AUG5\\A-24Lib\\employee.bin", FileMode.Open))
            {
                deserializedEmployee = (Employee)binaryFormatter.Deserialize(fileStream);
            }


            Console.WriteLine("Binary Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");




            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (FileStream fileStream = new FileStream("C:\\AUG5\\A-24Lib\\employee.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, employee);
            }
            using (FileStream fileStream = new FileStream("C:\\AUG5\\A-24Lib\\employee.xml", FileMode.Open))
            {
                deserializedEmployee = (Employee)xmlSerializer.Deserialize(fileStream);
            }


            Console.WriteLine("\nXML Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");

            Console.ReadKey();
        }
    }
}

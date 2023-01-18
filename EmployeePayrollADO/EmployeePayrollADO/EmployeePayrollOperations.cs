using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    public class EmployeePayrollOperations
    {
        public List<Employee> empList = new List<Employee>();
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void AddEmployeeDetails()
        {
            SqlCommand sqlCommand = new SqlCommand("spAddEmployeeDetails", this.sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Console.Write("Give Name: ");
            string name = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Name", name);
            Console.Write("Give Gender: ");
            string gender = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Gender", gender);
            Console.Write("Give PhoneNumber: ");
            string phone = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Phone", phone);
            Console.Write("Give Address: ");
            string address = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Address", address);
            Console.Write("Give Department: ");
            string department = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Department", department);
            Console.Write("Give Salary: ");
            string salary = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Salary", salary);
            Console.Write("Give Startdate: ");
            string startdate = Convert.ToString(Console.ReadLine());
            sqlCommand.Parameters.AddWithValue("@Startdate", startdate);

            sqlConnection.Open();
            int effectedRows = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (effectedRows >= 1)
            {
                Console.WriteLine("-----Employee Added Successfully-----");
            }
            else
                Console.WriteLine("-----Something Went Wrong-----");
        }

        public List<Employee> RetrieveEmployeeDetails()
        {
            SqlCommand sqlCommand = new SqlCommand("spGetAllEmployeeDetails", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                empList.Add(
                    new Employee
                    {
                        EmpId = Convert.ToInt32(dataRow["EmpId"]),
                        Name = Convert.ToString(dataRow["Name"]),
                        Gender = Convert.ToString(dataRow["Gender"]),
                        Phone = Convert.ToString(dataRow["Phone"]),
                        Address = Convert.ToString(dataRow["Address"]),
                        Department = Convert.ToString(dataRow["Department"]),
                        Salary = Convert.ToInt32(dataRow["Salary"]),
                        Startdate = Convert.ToDateTime(dataRow["Startdate"])
                    }
                    );
            }
            return empList;
        }
        public int UpdateEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update Employee Set Salary = @Salary Where Name = @Name", this.sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Name", "Terisa");

                sqlCommand.Parameters.AddWithValue("@Salary", "3000000");

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();

                return effectedRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void DeleteEmployeeDetails()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteEmployeeDetails", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give EmpId To Delete: ");
                int empId = Convert.ToInt32(Console.ReadLine());
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("-----Deleted Successfully-----");
                }
                else
                    Console.WriteLine("-----Something Went Wrong-----");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}
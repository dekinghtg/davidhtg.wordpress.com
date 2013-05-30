using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using CustomPagingWithOracle.Web.Entities;

namespace CustomPagingWithOracle.Web.BusinessObject
{
    [DataObject]
    public class EmployeeBusiness
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Employee> GetEmployee(int start, int limit)
        {


            int rowAwalYangDiambil;
            int rowTerakhirYangDiambil;

            if (start == 0)
            {
                rowAwalYangDiambil = 0;
                rowTerakhirYangDiambil = limit;
            }
            else
            {
                rowAwalYangDiambil = start + 1;
                rowTerakhirYangDiambil = start + limit;
            }

            string query = "SELECT * " +
                            "FROM (SELECT a.*, ROWNUM rnum " +
                            "FROM (  SELECT * " +
                            "FROM emp ) a " +
                            "WHERE ROWNUM <= :ROW_TERAKHIR_YANG_DIAMBIL)" +
                            "WHERE rnum >= :ROW_AWAL_YANG_DIAMBIL";
            IList<Employee> employees = new List<Employee>();
            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["scottconnectionstring"].ToString();
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Clear();
                OracleParameter parameter1 = new OracleParameter("ROW_TERAKHIR_YANG_DIAMBIL", OracleDbType.Int32, ParameterDirection.Input);
                parameter1.Value = rowTerakhirYangDiambil;
                OracleParameter parameter2 = new OracleParameter("ROW_AWAL_YANG_DIAMBIL", OracleDbType.Int32, ParameterDirection.Input);
                parameter2.Value = rowAwalYangDiambil;
                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                OracleDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmpNo = dr["EMPNO"] as Int16? ?? default(Int16);
                    employee.EName = dr["ENAME"] as string;
                    employee.HireDate = dr["HIREDATE"] as DateTime? ?? null;
                    employee.DeptNo = dr["DEPTNO"] as Int16? ?? null;
                    employee.Sal = dr["SAL"] as Single? ?? null;
                    employee.Comm = dr["COMM"] as Single? ?? null;
                    employee.Job = dr["JOB"] as string;
                    employee.Mgr = dr["MGR"] as Int16? ?? null;
                    employees.Add(employee);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return employees;
        }

        public int GetEmployeeCount(int start, int limit)
        {
            string queryCount = "SELECT COUNT(EMPNO) FROM EMP";
            int countResult;
            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["scottconnectionstring"].ToString();
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand(queryCount, connection);
                countResult = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return countResult;
        }

    }
}
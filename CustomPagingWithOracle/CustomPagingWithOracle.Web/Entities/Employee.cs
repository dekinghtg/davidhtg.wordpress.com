using System;
namespace CustomPagingWithOracle.Web.Entities
{

    public class Employee
    {
        private Int16 empNo;

        public Int16 EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }
        private string eName;

        public string EName
        {
            get { return eName; }
            set { eName = value; }
        }
        private string job;

        public string Job
        {
            get { return job; }
            set { job = value; }
        }
        private Int16? mgr;

        public Int16? Mgr
        {
            get { return mgr; }
            set { mgr = value; }
        }
        private DateTime? hireDate;

        public DateTime? HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }
        private Single? sal;

        public Single? Sal
        {
            get { return sal; }
            set { sal = value; }
        }
        private Single? comm;

        public Single? Comm
        {
            get { return comm; }
            set { comm = value; }
        }

        private Int16? deptNo;

        public Int16? DeptNo
        {
            get { return deptNo; }
            set { deptNo = value; }
        }
    }
}
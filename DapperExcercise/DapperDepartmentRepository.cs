using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DapperInClass;

namespace DapperExcercise
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("Select * From departments;");
        }

        
        

        internal void UpdateDepartment(int id, string newName)
        {
            throw new NotImplementedException();
        }
    }
}

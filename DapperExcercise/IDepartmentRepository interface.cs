using System;
using System.Collections.Generic;
using DapperExcercise;

namespace DapperInClass
{
    public interface IDepartmentRepository
    {
       
        
            IEnumerable<Department> GetAllDepartments();
        
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Dapper;
using System.Text.Json;
using WebAPIApp.Models;



namespace smartway_tryout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {

        private const string CONNECTION_STRING =
            @"Server=DESKTOP-30N0GBN\SQLEXPRESS;Database=smartway;Trusted_Connection=True;";


        [HttpGet]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult GetEmployeesCompany([FromForm] GetEmployeesCompanyDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                var result = connection.Query("SELECT * FROM Employees WHERE company_id=@company_id", data);

                return Ok(result);
            }
        }


        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Post([FromForm] InsertEmployeesDataModel data)
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                var result_employee_id = connection.QuerySingle<int>("INSERT INTO Employees (name,surname,phone,company_id,passport_id)  output INSERTED.ID VALUES (@name,@surname,@phone,@company_id,@passport_id);", data);

                
                return Ok(result_employee_id);
            }


        }


        [HttpPut]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Put([FromForm] UpdateEmployeesDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))

            {
                var result_update_employee = connection.Execute("UPDATE Employees SET " + data.key + " = @value WHERE id = @id", data);

                return Ok(result_update_employee);
            }

        }


        [HttpDelete]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Delete([FromForm] DeleteEmployeesDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var result_delete = connection.Execute("DELETE FROM Employees WHERE id = @id", data);

                return Ok(result_delete);
            }

        }
    }

}

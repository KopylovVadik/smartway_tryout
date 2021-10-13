using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Dapper;
using WebAPIApp.Models;


namespace smartway_tryout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentController : ControllerBase
    {

        private const string CONNECTION_STRING =
            @"Server=DESKTOP-30N0GBN\SQLEXPRESS;Database=smartway;Trusted_Connection=True;";

        
        [HttpGet]
        public ActionResult Get()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                var result = connection.Query("SELECT * FROM Department");

                return Ok(result);
            }
        }

        

       
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Post([FromForm] InsertDepartmentDataModel data )
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                var result_insert_department = connection.Execute("INSERT INTO Department (id,name,phone) VALUES (@id,@name,@phone)", data);

                return Ok(result_insert_department);
            }

        }

        
        [HttpPut]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Put([FromForm] UpdateDepartmentDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))

            {
                var result_update_department = connection.Execute("UPDATE Department SET " + data.key + "= @value WHERE id =@id", data);

                return Ok(result_update_department);
            }

        }

        
        [HttpDelete]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Delete ([FromForm]DeleteDepartmentDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var result_delete_department = connection.Execute("DELETE FROM Department WHERE id = @id", data);

                return Ok(result_delete_department);
            }

        }
    
    }


}

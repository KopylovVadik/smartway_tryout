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
    public class passportController : ControllerBase
    {
        private const string CONNECTION_STRING =
           @"Server=DESKTOP-30N0GBN\SQLEXPRESS;Database=smartway;Trusted_Connection=True;";

        [HttpGet]
        public ActionResult Get()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                var result = connection.Query("SELECT * FROM Passport");

                return Ok(result);
            }
        }

        
    
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Post([FromForm] InsertPassportDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {

                var result_insert_passport = connection.Execute("INSERT INTO Passport (id,type,number) VALUES (@id,@type,@number)", data);

                return Ok(result_insert_passport);
            }

        }

        
        [HttpPut]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Put(int id, [FromForm] UpdatePassportDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))

            {
                var result_update_passport = connection.Execute("UPDATE Passport SET " + data.key + "= @value WHERE id =@id", data);

                return Ok(result_update_passport);
            }


        }

       
        [HttpDelete]
        [Consumes("application/x-www-form-urlencoded")]
        public ActionResult Delete([FromForm] DeletePassportDataModel data)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var result_delete_passport = connection.Execute("DELETE FROM Passport WHERE id = @id", data);

                return Ok(result_delete_passport);
            }

        }
    }


}

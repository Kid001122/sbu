using HodlSolution.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HodlSolution.Controllers
{
    public class BrokerController : Controller
    {
        private readonly string connectionString = "Server=129.232.251.122;Database=hodlotc_db;Uid=hodladmin;Pwd=L3mWjfUDK2md8yMUb698";
        [Route("api/BrokerInsert")]
        [HttpPost]
        public IActionResult CreateBroker([FromBody] Brokers brokersm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO BrokerTable (BrokerID,Date,Email,IdNumber,Name,Surname,Status,Link) \r\nVALUES (@BrokerID,@Date,@Email,@IdNumber,@Name,@Surname,@Status,@Link)\r\n";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@BrokerID", brokersm.BrokerID);
                        cmd.Parameters.AddWithValue("@Date", brokersm.Date);
                        cmd.Parameters.AddWithValue("@Email", brokersm.Email);
                        cmd.Parameters.AddWithValue("@IdNumber", brokersm.IdNumber);
                        cmd.Parameters.AddWithValue("@Name", brokersm.Name);
                        cmd.Parameters.AddWithValue("@Surname", brokersm.Surname);
                        cmd.Parameters.AddWithValue("@Status", brokersm.Status);
                        cmd.Parameters.AddWithValue("@Link", brokersm.Link);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok("Friend referred added successfully");
                        }
                        else
                        {
                            return BadRequest("Failed to add friend referred");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/BrokerSelect")]
        [HttpGet]
        public IActionResult GetAllBrokers()
        {
            try
            {
                List<Brokers> brokerss = new List<Brokers>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM BrokerTable";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Brokers brokersm = new Brokers
                                {
                                    BrokerID = reader.IsDBNull(reader.GetOrdinal("BrokerID")) ? 0 : reader.GetInt32(reader.GetOrdinal("BrokerID")),
                                    Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    IdNumber = reader.IsDBNull(reader.GetOrdinal("IdNumber")) ? null : reader.GetString(reader.GetOrdinal("IdNumber")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                                    Surname = reader.IsDBNull(reader.GetOrdinal("Surname")) ? null : reader.GetString(reader.GetOrdinal("Surname")),
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                                    Link = reader.IsDBNull(reader.GetOrdinal("Link")) ? null : reader.GetString(reader.GetOrdinal("Link"))

                                };
                                brokerss.Add(brokersm);
                            }
                        }
                    }
                }

                return Ok(brokerss);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/BrokerSelectFiltered")]
        [HttpGet]
        public IActionResult GetAllBrokerFiltered(Dictionary<string, string> filters)
        {
            try
            {
                List<Brokers> brokers = new List<Brokers>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM BrokerTable";
                    if (filters != null && filters.Count > 0)
                    {
                        List<string> filterConditions = new List<string>();

                        foreach (var filter in filters)
                        {
                            filterConditions.Add($"{filter.Key} = '{filter.Value}'");
                        }
                        string filterString = string.Join(" AND ", filterConditions);

                        sql += " WHERE " + filterString;
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Brokers brokersm = new Brokers
                                {
                                    BrokerID = reader.IsDBNull(reader.GetOrdinal("BrokerID")) ? 0 : reader.GetInt32(reader.GetOrdinal("BrokerID")),
                                    Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    IdNumber = reader.IsDBNull(reader.GetOrdinal("IdNumber")) ? null : reader.GetString(reader.GetOrdinal("IdNumber")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                                    Surname = reader.IsDBNull(reader.GetOrdinal("Surname")) ? null : reader.GetString(reader.GetOrdinal("Surname")),
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                                    Link = reader.IsDBNull(reader.GetOrdinal("Link")) ? null : reader.GetString(reader.GetOrdinal("Link"))
                                };
                                brokers.Add(brokersm);
                            }
                        }
                    }
                }

                return Ok(brokers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/BrokerUpdate")]
        [HttpPut]
        public IActionResult BrokerUpdate([FromBody] Brokers brokersm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE BrokerTable SET ";
                    List<string> fieldsToUpdate = new List<string>();

                    

                    if (!string.IsNullOrEmpty(brokersm.Email))
                    {
                        fieldsToUpdate.Add("Email = @Email");
                    }


                    if (!string.IsNullOrEmpty(brokersm.IdNumber))
                    {
                        fieldsToUpdate.Add("IdNumber = @IdNumber");
                    }

                    if (!string.IsNullOrEmpty(brokersm.Name))
                    {
                        fieldsToUpdate.Add("Name = @Name");
                    }

                    if (!string.IsNullOrEmpty(brokersm.Surname))
                    {
                        fieldsToUpdate.Add("Surname = @Surname");
                    }

                    if (!string.IsNullOrEmpty(brokersm.Status))
                    {
                        fieldsToUpdate.Add("Status = @Status");
                    }

                    if (!string.IsNullOrEmpty(brokersm.Link))
                    {
                        fieldsToUpdate.Add("Link = @Link");
                    }

                    sql += string.Join(", ", fieldsToUpdate);
                    sql += " WHERE Email = @Email";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@BrokerID", brokersm.BrokerID);
                        cmd.Parameters.AddWithValue("@Email", brokersm.Email);
                        cmd.Parameters.AddWithValue("@IdNumber", brokersm.IdNumber);
                        cmd.Parameters.AddWithValue("@Name", brokersm.Name);
                        cmd.Parameters.AddWithValue("@Surname", brokersm.Surname);
                        cmd.Parameters.AddWithValue("@Status", brokersm.Status);
                        cmd.Parameters.AddWithValue("@Link", brokersm.Link);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok("Friend referred updated successfully");
                        }
                        else
                        {
                            return NotFound("Friend referred not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/BrokerDelete")]
        [HttpDelete]
        public IActionResult DeleteBroker(string Email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM BrokerTable WHERE Email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok("Friend referred deleted successfully");
                        }
                        else
                        {
                            return NotFound("Friend referred not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

using HodlSolution.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HodlSolution.Controllers
{
    public class friendreferredController : Controller
    {
        private readonly string connectionString = "Server=129.232.251.122;Database=hodlotc_db;Uid=hodladmin;Pwd=L3mWjfUDK2md8yMUb698";
        [Route("api/FriendReferredInsert")]
        [HttpPost]
        public IActionResult CreateFriendReferred([FromBody] friendreferred friendReferredm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO friendsreferred (FriendReferredId,Date,Email,IdNumber,Name,Surname,Level,Status,Link) \r\nVALUES (@FriendReferredId,@Date,@Email,@IdNumber,@Name,@Surname,@Level,@Status,@Link)\r\n";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FriendReferredId", friendReferredm.FriendReferredId);
                        cmd.Parameters.AddWithValue("@Date", friendReferredm.Date);
                        cmd.Parameters.AddWithValue("@Email", friendReferredm.Email);
                        cmd.Parameters.AddWithValue("@IdNumber", friendReferredm.IdNumber);
                        cmd.Parameters.AddWithValue("@Name", friendReferredm.Name);
                        cmd.Parameters.AddWithValue("@Surname", friendReferredm.Surname);
                        cmd.Parameters.AddWithValue("@Level", friendReferredm.Level);
                        cmd.Parameters.AddWithValue("@Status", friendReferredm.Status);
                        cmd.Parameters.AddWithValue("@Link", friendReferredm.Link);

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
        [Route("api/FriendReferredSelect")]
        [HttpGet]
        public IActionResult GetAllFriendsReferred()
        {
            try
            {
                List<friendreferred> friendsReferreds = new List<friendreferred>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM friendsreferred";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                friendreferred friendReferredm = new friendreferred
                                {
                                    FriendReferredId = reader.IsDBNull(reader.GetOrdinal("FriendReferredId")) ? 0 : reader.GetInt32(reader.GetOrdinal("FriendReferredId")),
                                    Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    IdNumber = reader.IsDBNull(reader.GetOrdinal("IdNumber")) ? null : reader.GetString(reader.GetOrdinal("IdNumber")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                                    Surname = reader.IsDBNull(reader.GetOrdinal("Surname")) ? null : reader.GetString(reader.GetOrdinal("Surname")),
                                    Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? null : reader.GetString(reader.GetOrdinal("Level")),
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                                    Link = reader.IsDBNull(reader.GetOrdinal("Link")) ? null : reader.GetString(reader.GetOrdinal("Link"))

                                };
                                friendsReferreds.Add(friendReferredm);
                            }
                        }
                    }
                }

                return Ok(friendsReferreds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/FriendReferredSelectFiltered")]
        [HttpGet]
        public IActionResult GetAllFriendsReferredFiltered( Dictionary<string, string> filters)
        {
            try
            {
                List<friendreferred> friendsReferreds = new List<friendreferred>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM friendsreferred";
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
                                friendreferred friendReferredm = new friendreferred
                                {
                                    FriendReferredId = reader.IsDBNull(reader.GetOrdinal("FriendReferredId")) ? 0 : reader.GetInt32(reader.GetOrdinal("FriendReferredId")),
                                    Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    IdNumber = reader.IsDBNull(reader.GetOrdinal("IdNumber")) ? null : reader.GetString(reader.GetOrdinal("IdNumber")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString(reader.GetOrdinal("Name")),
                                    Surname = reader.IsDBNull(reader.GetOrdinal("Surname")) ? null : reader.GetString(reader.GetOrdinal("Surname")),
                                    Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? null : reader.GetString(reader.GetOrdinal("Level")),
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                                    Link = reader.IsDBNull(reader.GetOrdinal("Link")) ? null : reader.GetString(reader.GetOrdinal("Link"))
                                };
                                friendsReferreds.Add(friendReferredm);
                            }
                        }
                    }
                }

                return Ok(friendsReferreds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/FriendReferredUpdate")]
        [HttpPut]
        public IActionResult UpdateFriendReferred([FromBody] friendreferred friendReferredm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE friendsreferred SET ";
                    List<string> fieldsToUpdate = new List<string>();

                    if (!string.IsNullOrEmpty(friendReferredm.Email))
                    {
                        fieldsToUpdate.Add("Email = @Email");
                    }


                    if (!string.IsNullOrEmpty(friendReferredm.IdNumber))
                    {
                        fieldsToUpdate.Add("IdNumber = @IdNumber");
                    }

                    if (!string.IsNullOrEmpty(friendReferredm.Name))
                    {
                        fieldsToUpdate.Add("Name = @Name");
                    }

                    if (!string.IsNullOrEmpty(friendReferredm.Surname))
                    {
                        fieldsToUpdate.Add("Surname = @Surname");
                    }

                    if (!string.IsNullOrEmpty(friendReferredm.Level))
                    {
                        fieldsToUpdate.Add("Level = @Level");
                    }

                    if (!string.IsNullOrEmpty(friendReferredm.Status))
                    {
                        fieldsToUpdate.Add("Status = @Status");
                    }

                    if (!string.IsNullOrEmpty(friendReferredm.Link))
                    {
                        fieldsToUpdate.Add("Link = @Link");
                    }

                    sql += string.Join(", ", fieldsToUpdate);
                    sql += " WHERE ReferredEmail = @ReferredEmail"; 

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FriendReferredId", friendReferredm.FriendReferredId);
                        cmd.Parameters.AddWithValue("@Email", friendReferredm.Email);
                        cmd.Parameters.AddWithValue("@IdNumber", friendReferredm.IdNumber);
                        cmd.Parameters.AddWithValue("@Name", friendReferredm.Name);
                        cmd.Parameters.AddWithValue("@Surname", friendReferredm.Surname);
                        cmd.Parameters.AddWithValue("@Level", friendReferredm.Level);
                        cmd.Parameters.AddWithValue("@Status", friendReferredm.Status);
                        cmd.Parameters.AddWithValue("@Link", friendReferredm.Link);

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

        [Route("api/FriendReferredDelete")]
        [HttpDelete]
        public IActionResult DeleteFriendReferred(string Email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM friendsreferred WHERE ReferredEmail = @ReferredEmail";
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

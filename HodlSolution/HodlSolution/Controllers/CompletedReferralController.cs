using HodlSolution.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HodlSolution.Controllers
{
    public class CompletedReferralController : Controller
    {
        private readonly string connectionString = "Server=129.232.251.122;Database=hodlotc_db;Uid=hodladmin;Pwd=L3mWjfUDK2md8yMUb698";
        [Route("api/CompletedReferralInsert")]
        [HttpPost]
        public IActionResult CreateFriendReferred([FromBody] CompletedReferral CompletedReferralm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO CompletedReferral (CompletedReferralId,Link,Email,TradeAmount,Commission,Balance) \r\nVALUES (@CompletedReferralId,@Link,@Email,@TradeAmount,@Commission,@Balance)\r\n";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CompletedReferralId", CompletedReferralm.CompletedReferralId);
                        cmd.Parameters.AddWithValue("@Link", CompletedReferralm.Link);
                        cmd.Parameters.AddWithValue("@Email", CompletedReferralm.Email);
                        cmd.Parameters.AddWithValue("@TradeAmount", CompletedReferralm.TradeAmount);
                        cmd.Parameters.AddWithValue("@Commission", CompletedReferralm.Commission);
                        cmd.Parameters.AddWithValue("@Balance", CompletedReferralm.Balance);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Ok("Referred Successfully");
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
        [Route("api/CompletedReferralSelect")]
        [HttpGet]
        public IActionResult GetAllFriendsReferred()
        {
            try
            {
                List<CompletedReferral> CompletedReferrals = new List<CompletedReferral>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM CompletedReferral";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompletedReferral CompletedReferralm = new CompletedReferral
                                {
                                    CompletedReferralId = reader.IsDBNull(reader.GetOrdinal("CompletedReferralId")) ? 0 : reader.GetInt32(reader.GetOrdinal("CompletedReferralId")),
                                    Link = reader.IsDBNull(reader.GetOrdinal("Link")) ? null : reader.GetString(reader.GetOrdinal("Link")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    TradeAmount = reader.IsDBNull(reader.GetOrdinal("TradeAmount")) ? 0 : reader.GetInt32(reader.GetOrdinal("TradeAmount")),
                                    Commission = reader.IsDBNull(reader.GetOrdinal("Commission")) ? 0 : reader.GetInt32(reader.GetOrdinal("Commission")),
                                    Balance = reader.IsDBNull(reader.GetOrdinal("Balance")) ? 0 : reader.GetInt32(reader.GetOrdinal("Balance")),
                                };
                                CompletedReferrals.Add(CompletedReferralm);
                            }
                        }
                    }
                }

                return Ok(CompletedReferrals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/CompletedReferralSelectFiltered")]
        [HttpGet]
        public IActionResult GetAllFriendsReferredFiltered(Dictionary<string, string> filters)
        {
            try
            {
                List<CompletedReferral> CompletedReferrals = new List<CompletedReferral>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM CompletedReferral";
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
                                CompletedReferral CompletedReferralm = new CompletedReferral
                                {
                                    CompletedReferralId = reader.IsDBNull(reader.GetOrdinal("CompletedReferralId")) ? 0 : reader.GetInt32(reader.GetOrdinal("CompletedReferralId")),
                                    Link = reader.IsDBNull(reader.GetOrdinal("Link")) ? null : reader.GetString(reader.GetOrdinal("Link")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    TradeAmount = reader.IsDBNull(reader.GetOrdinal("TradeAmount")) ? 0 : reader.GetInt32(reader.GetOrdinal("TradeAmount")),
                                    Commission = reader.IsDBNull(reader.GetOrdinal("Commission")) ? 0 : reader.GetInt32(reader.GetOrdinal("Commission")),
                                    Balance = reader.IsDBNull(reader.GetOrdinal("Balance")) ? 0 : reader.GetInt32(reader.GetOrdinal("Balance")),
                                };
                                CompletedReferrals.Add(CompletedReferralm);
                            }
                        }
                    }
                }

                return Ok(CompletedReferrals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("api/CompletedReferralUpdate")]
        [HttpPut]
        public IActionResult UpdateFriendReferred([FromBody] CompletedReferral CompletedReferralm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE CompletedReferral SET ";
                    List<string> fieldsToUpdate = new List<string>();

                    if (!string.IsNullOrEmpty(CompletedReferralm.Link))
                    {
                        fieldsToUpdate.Add("Email = @Email");
                    }


                    if (!string.IsNullOrEmpty(CompletedReferralm.Link))
                    {
                        fieldsToUpdate.Add("Link = @Link");
                    }
                    if (CompletedReferralm.TradeAmount>0)
                    {
                        fieldsToUpdate.Add("TradeAmount = @TradeAmount");
                    }
                    if (CompletedReferralm.Commission>0)
                    {
                        fieldsToUpdate.Add("Commission= @Commission");
                    }
                    if (CompletedReferralm.Balance>0)
                    {
                        fieldsToUpdate.Add("Balance = @Balance");
                    }

                    sql += string.Join(", ", fieldsToUpdate);
                    sql += " WHERE Link = @Link";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CompletedReferralId", CompletedReferralm.CompletedReferralId);
                        cmd.Parameters.AddWithValue("@Link", CompletedReferralm.Link);
                        cmd.Parameters.AddWithValue("@Email", CompletedReferralm.Email);
                        cmd.Parameters.AddWithValue("@TradeAmount", CompletedReferralm.TradeAmount);
                        cmd.Parameters.AddWithValue("@Commission", CompletedReferralm.Commission);
                        cmd.Parameters.AddWithValue("@Balance", CompletedReferralm.Balance);


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
        [Route("api/CompletedReferralDelete")]
        [HttpDelete]
        public IActionResult DeleteFriendReferred(CompletedReferral CompletedReferralm)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM CompletedReferral WHERE Email = @Email";
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", CompletedReferralm.Email);

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

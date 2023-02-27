namespace StrainBrain.Models.DTOs.Responses;

public class UserResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string? AccessToken { get; set; }
    public double? UserBalance { get; set; }
    public string? UserScore { get; set; }
}

namespace OnderzoekDapper.models;

public class User
{
    public int Id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    public string Email { get; set; }
    public string Password_hash { get; set; }
    // public DateTime Created_at { get; set; }
}

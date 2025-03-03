namespace OnderzoekDapper.models.Joins;

public class ServerSpeed
{
    public int ServerId { get; set; }
    public string ServerName { get; set; }
    public string ConnectionType { get; set; }
    public int Bandwidth { get; set; }
}
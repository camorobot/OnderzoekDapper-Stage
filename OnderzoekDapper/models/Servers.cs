namespace OnderzoekDapper.models;

public class Servers
{
    public int ServerId { get; set; }
    public string ServerName { get; set; }
    public string IPAddress { get; set; }
    public string OS { get; set; }
    public int LocationId { get; set; }
    public int RackmountId { get; set; }
}
namespace OnderzoekDapper.models;

public class NetworkConnection
{
    private int ConnectionId { get; set; }
    private int ServerId { get; set; }
    private int SwitchId { get; set; }
    private string ConnectionType { get; set; }
    private int BandWidth { get; set; }
}
namespace Taiseiue.Nenga2025;

public class Lot
{
    /// <summary>
    /// くじの番号
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// くじについてくるメッセージ
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// 当たりくじの場合は、アマギフのUrl
    /// </summary>
    public string? GiftUrl { get; set; }
    /// <summary>
    /// 開封日
    /// </summary>
    public DateTime? OpenedAt { get; set; }
}
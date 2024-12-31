namespace Taiseiue.Nenga2025;

public class PostCard
{
    public int Id { get; set; }
    public int Group { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    /// <summary>
    /// くじで当たりを引いている場合は、そのくじの番号
    /// </summary>
    public int? Lot { get; set; }
}
using Microsoft.EntityFrameworkCore;

namespace Taiseiue.Nenga2025;

public class Db : DbContext
{
    public DbSet<PostCard> PostCards { get; set; }
    public DbSet<Lot> Lots { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        // デバッグ中は、Dockerで立っているDBに外から接続する
        optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=nenga; User ID=sa; Password=jMJWpbHG75Gw; Encrypt=False;");
#else
            // 本番環境では、Docker内のDBに接続する
        optionsBuilder.UseSqlServer(@"Data Source=db; Initial Catalog=nenga; User ID=sa; Password=jMJWpbHG75Gw; Encrypt=False;");
#endif
    }
}
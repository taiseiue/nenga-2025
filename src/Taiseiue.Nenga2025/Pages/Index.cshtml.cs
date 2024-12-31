using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taiseiue.Nenga2025.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public int Group { get; set; }

    [BindProperty]
    public int Number { get; set; }
    public bool WasPosted { get; set; }
    public string Error { get; set; }
    public static Random _Rand = new Random();
    public PostCard PostCard { get; set; }
    public Lot Lot { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        WasPosted = false;
    }
    public async void OnPost()
    {
        WasPosted = true;
        Db db = new Db();

        // 当たってるかを調べる
        PostCard = db.PostCards.FirstOrDefault(p => p.Group == Group && p.Number == Number);
        if (PostCard == null)
        {
            Error = "該当するはがきがありません";
            return;
        }
        PostCard.OpenedAt = DateTime.Now;

        // くじを引いている場合はそれを表示する
        if (PostCard.Lot != null)
        {
            Lot = db.Lots.FirstOrDefault(l => l.Id == PostCard.Lot);
            return;
        }

        // 残りくじを取得
        var lots = db.Lots.Where(l => l.OpenedAt == null);

        // くじを引く
        Lot = lots.ElementAt(_Rand.Next(lots.Count()));
        Lot.OpenedAt = DateTime.Now;

        // 引いたくじを記録しておく
        PostCard.Lot = Lot.Id;

        // Dbに記録
        db.SaveChangesAsync();
    }
}

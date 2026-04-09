using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class ChatLieu
{
    public int MaChatLieu { get; set; }

    public string TenChatLieu { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

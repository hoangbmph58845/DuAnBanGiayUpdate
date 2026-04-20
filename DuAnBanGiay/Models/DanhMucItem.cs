namespace DuAnBanGiay.Models;

internal sealed class DanhMucItem
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public override string ToString() => Name;
}


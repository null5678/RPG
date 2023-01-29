
public class Command
{
    /// <summary>
    /// コマンドのタイプ(たたかう、特技、道具、にげる)
    /// </summary>
    public CommandType Type { get; set; }

    /// <summary>
    /// 行動するキャラ
    /// </summary>
    public Character Self { get; set; }

    /// <summary>
    /// 対象のキャラ
    /// </summary>
    public Character Target { get; set; }
}

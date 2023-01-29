
public class Character
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Attack { get; private set; }
    public int Speed { get; private set; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="data">パラメータ</param>
    public Character(ICharacterData data)
    {
        Name = data.Name;
        Hp = data.Hp;
        Attack = data.Attack;
        Speed = data.Speed;
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage">ダメージ</param>
    public virtual void Damage(int damage)
    {
        Hp -= damage;
    }
}

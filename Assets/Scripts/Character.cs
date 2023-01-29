
public class Character
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Attack { get; private set; }
    public int Speed { get; private set; }

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="data">�p�����[�^</param>
    public Character(ICharacterData data)
    {
        Name = data.Name;
        Hp = data.Hp;
        Attack = data.Attack;
        Speed = data.Speed;
    }

    /// <summary>
    /// �_���[�W���󂯂�
    /// </summary>
    /// <param name="damage">�_���[�W</param>
    public virtual void Damage(int damage)
    {
        Hp -= damage;
    }
}

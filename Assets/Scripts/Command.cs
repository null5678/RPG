
public class Command
{
    /// <summary>
    /// �R�}���h�̃^�C�v(���������A���Z�A����A�ɂ���)
    /// </summary>
    public CommandType Type { get; set; }

    /// <summary>
    /// �s������L����
    /// </summary>
    public Character Self { get; set; }

    /// <summary>
    /// �Ώۂ̃L����
    /// </summary>
    public Character Target { get; set; }
}

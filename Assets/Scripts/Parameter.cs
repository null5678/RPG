using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Parameter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _hp;

    public string Name { get; private set; }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="player">�v���C���[���</param>
    public void Init(Player player)
    {
        Name = player.Name;
        _name.SetText(player.Name);
        UpdateParameter(player);
    }

    /// <summary>
    /// �p�����[�^�X�V
    /// </summary>
    /// <param name="player">�v���C���[���</param>
    public void UpdateParameter(Player player)
    {
        _hp.SetText(player.Hp.ToString());
    }
}

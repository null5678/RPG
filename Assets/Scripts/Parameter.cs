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
    /// 初期化
    /// </summary>
    /// <param name="player">プレイヤー情報</param>
    public void Init(Player player)
    {
        Name = player.Name;
        _name.SetText(player.Name);
        UpdateParameter(player);
    }

    /// <summary>
    /// パラメータ更新
    /// </summary>
    /// <param name="player">プレイヤー情報</param>
    public void UpdateParameter(Player player)
    {
        _hp.SetText(player.Hp.ToString());
    }
}

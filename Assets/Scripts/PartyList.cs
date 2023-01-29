using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyList : MonoBehaviour
{
    private const int kPrefabWidth = 200;
    private const int kEdgeSize = 20;

    [SerializeField]
    private GameObject _parameterPrefab;
    [SerializeField]
    private Transform _parameterParent;

    private List<Parameter> _parameterList = new List<Parameter>();

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="players">プレイヤー情報</param>
    public void Init(Player[] players)
    {
        int w = (kPrefabWidth * players.Length) + kEdgeSize;
        var r = GetComponent<RectTransform>();
        r.sizeDelta = new Vector2(w, r.sizeDelta.y);

        foreach(var v in players)
        {
            Parameter para = Instantiate(_parameterPrefab, _parameterParent).GetComponent<Parameter>();
            para.Init(v);
            _parameterList.Add(para);
        }
    }

    /// <summary>
    /// パラメータ更新
    /// </summary>
    /// <param name="players">プレイヤー情報</param>
    public void UpdateParameter(Player[] players)
    {
        foreach(var v in players)
        {
            EqualsParameterName(v.Name)?.UpdateParameter(v);
        }
    }

    /// <summary>
    /// 同じ名前のものを取り出す
    /// </summary>
    /// <param name="name">名前</param>
    /// <returns></returns>
    private Parameter EqualsParameterName(string name)
    {
        foreach(var v in _parameterList)
        {
            if(v.Name.Equals(name))
            {
                return v;
            }
        }

        return null;
    }
}

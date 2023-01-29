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
    /// ������
    /// </summary>
    /// <param name="players">�v���C���[���</param>
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
    /// �p�����[�^�X�V
    /// </summary>
    /// <param name="players">�v���C���[���</param>
    public void UpdateParameter(Player[] players)
    {
        foreach(var v in players)
        {
            EqualsParameterName(v.Name)?.UpdateParameter(v);
        }
    }

    /// <summary>
    /// �������O�̂��̂����o��
    /// </summary>
    /// <param name="name">���O</param>
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

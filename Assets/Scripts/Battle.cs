using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

public class Battle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _playerNameTex;
    [SerializeField]
    private TextMeshProUGUI _playerHpTex;
    [SerializeField]
    private TextMeshProUGUI _enemyTex;
    [SerializeField]
    private Button _fightBtn;
    [SerializeField]
    private GameObject _commandObj;
    [SerializeField]
    private GameObject _logObj;
    [SerializeField]
    private TextMeshProUGUI _logTex;
    [SerializeField]
    private PartyList _partyList;

    //private Player _player = new Player();
    //private Enemy _enemy = new Enemy();

    private List<Player> _playerList = new List<Player>();
    private List<Enemy> _enemyList = new List<Enemy>();

    private List<Command> _commandList = new List<Command>();

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// ������
    /// </summary>
    private void Init()
    {
        ICharacterData[] datas = DummyDataGenerate();

        foreach(var v in datas)
        {
            if(v is PlayerData p)
            {
                _playerList.Add(new Player(p));
            }
            else if(v is EnemyData e)
            {
                _enemyList.Add(new Enemy(e));
            }
        }

        _partyList.Init(_playerList.ToArray());

        //_player.Init(datas[0]);

        //_enemy.Init(datas[1]);

        UpdateText();

        //_playerNameTex.SetText(_player.Name);

        _fightBtn.onClick.AddListener(OnClickTestButton);

        _logObj.SetActive(false);
    }

    /// <summary>
    /// �o�g���̃��C�����[�`��
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async UniTask UpdateBattle(CancellationToken cancellationToken)
    {
        SpeedSort();

        foreach (var v in _commandList)
        {
            switch (v.Type)
            {
                case CommandType.Fight:
                    v.Target.Damage(v.Self.Attack);
                    break;
                case CommandType.Skill:
                    break;
                case CommandType.Tool:
                    break;
                case CommandType.Escape:
                    break;
            }

            UpdateText();

            _logObj.SetActive(true);
            string log = v.Target.Name + "��" +
                         v.Self.Attack.ToString() + "�̃_���[�W�I";
            _logTex.SetText(log);

            _commandObj.SetActive(false);

            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.A));
        }

        _logObj.SetActive(false);
        _commandObj.SetActive(true);
    }

    /// <summary>
    /// ���Ńe�L�X�g���X�V�������
    /// </summary>
    private void UpdateText()
    {
        _partyList.UpdateParameter(_playerList.ToArray());

        string enemyTex = "HP : " + _enemyList[0].Hp.ToString() + "\n" +
                          "AT : " + _enemyList[0].Attack.ToString() + "\n";

        _enemyTex.SetText(enemyTex);
    }

    /// <summary>
    /// ���΂₳�������Ƀ\�[�g
    /// </summary>
    private void SpeedSort()
    {
        _commandList.Sort((a, b) => b.Self.Speed - a.Self.Speed);
    }

    /// <summary>
    /// ���������{�^���C�x���g
    /// (�������̂܂܎g��Ȃ�����)
    /// </summary>
    private void OnClickTestButton()
    {
        _commandList.Clear();

        var command = new Command();
        command.Self = _playerList[0];
        command.Target = _enemyList[0];

        var command1 = new Command();
        command1.Self = _enemyList[0];
        command1.Target = _playerList[0];

        _commandList.Add(command);
        _commandList.Add(command1);

        UpdateBattle(this.GetCancellationTokenOnDestroy()).Forget();
    }

    /// <summary>
    /// �����ƓG�̃f�[�^�쐬
    /// </summary>
    /// <returns></returns>
    private ICharacterData[] DummyDataGenerate()
    {
        List<ICharacterData> datas = new List<ICharacterData>();
        var player = new PlayerData()
        {
            Name = "�ɂ񂰂�P",
            Hp = 100,
            Attack = 10,
            Speed = 5,
        };
        var player2 = new PlayerData()
        {
            Name = "�ɂ񂰂�2",
            Hp = 100,
            Attack = 10,
            Speed = 5,
        };
        var enemy = new EnemyData()
        {
            Name = "�Ă��P",
            Hp = 100,
            Attack = 10,
            Speed = 10,
        };

        datas.Add(player);
        datas.Add(player2);
        datas.Add(enemy);

        return datas.ToArray();
    }
}

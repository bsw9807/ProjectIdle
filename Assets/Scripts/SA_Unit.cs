using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Unit : MonoBehaviour
{
    public SPUM_Prefabs _spumPref;

    public enum UnitState
    {
        idle,
        move,
        stun,
        attack,
        skill,
        death,

    }

    public UnitState _unitState = UnitState.idle;

    public SA_Unit _target;

    //ü��
    public float _unitHP;
    //����
    public float _unitDF;

    //�̵��ӵ�
    public float _unitMS;

    //���ݷ�
    public float _unitAT;
    //���ݼӵ�
    public float _unitAS;
    //��Ÿ�
    public float _unitAR;

    void Update()
    {
        CheckState();
    }

    void SetInitState()
    {
        _unitState = UnitState.idle;
    }

    void CheckState()
    {
        switch (_unitState)
        {
            case UnitState.idle:
                FindTarget();
                break;
            case UnitState.move:
                FindTarget();
                break;
            case UnitState.stun:
                break;
            case UnitState.attack:
                break;
            case UnitState.skill:
                break;
            case UnitState.death:
                break;
        }
    }

    void FindTarget()
    {
        _target = SoonsoonData.Instance._sAManager.GetTarget(this);
    }

}

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

    //체력
    public float _unitHP;
    //방어력
    public float _unitDF;

    //이동속도
    public float _unitMS;

    //공격력
    public float _unitAT;
    //공격속도
    public float _unitAS;
    //사거리
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

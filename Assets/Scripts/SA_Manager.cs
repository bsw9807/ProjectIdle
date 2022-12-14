using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Manager : MonoBehaviour
{
    public List<Transform> _unitPool = new List<Transform>();

    public List<SA_Unit> _p1UnitList = new List<SA_Unit>();

    public List<SA_Unit> _p2UnitList = new List<SA_Unit>();

    public List<SA_Unit> _p3UnitList = new List<SA_Unit>();

    void Awake()
    {
        SoonsoonData.Instance._sAManager = this;
    }

    void Start()
    {
        SetUnitList();
    }

    void Update()
    {
        
    }

    //유닛 정보 연결
    void SetUnitList()
    {
        _p1UnitList.Clear();
        _p2UnitList.Clear();
        _p3UnitList.Clear();
        for (var i = 0; i < _unitPool.Count; i++)
        {
            for(var j = 0; j < _unitPool[i].childCount; j++)
            {
                switch (i)
                {
                    case 0:
                        _p1UnitList.Add(_unitPool[i].GetChild(j).GetComponent<SA_Unit>());
                        _unitPool[i].GetChild(j).gameObject.tag = "P1";
                        break;

                    case 1:
                        _p2UnitList.Add(_unitPool[i].GetChild(j).GetComponent<SA_Unit>());
                        _unitPool[i].GetChild(j).gameObject.tag = "P2";
                        break;

                    case 2:
                        _p3UnitList.Add(_unitPool[i].GetChild(j).GetComponent<SA_Unit>());
                        _unitPool[i].GetChild(j).gameObject.tag = "P3";
                        break;

                }
            }
        }
    }

    public SA_Unit GetTarget(SA_Unit unit)
    {
        SA_Unit tUnit = null;

        List<SA_Unit> tList = new List<SA_Unit>();
        switch (unit.tag)
        {
            case "P1": tList = _p1UnitList; break;
            case "P2": tList = _p1UnitList; break;
        }

        float tSDis = 999999;

        for(var i=0; i < tList.Count; i++)
        {
            float tDis = ((Vector2)tList[0].transform.localPosition - (Vector2)unit.transform.localPosition).sqrMagnitude;
            if(tDis <= unit._unitAR * unit._unitAR)
            {
                if (!tList[i].gameObject.activeInHierarchy)
                {
                    if (tList[i]._unitState != SA_Unit.UnitState.death)
                    {
                        if (tDis < tSDis)
                        {
                            tUnit = tList[i];
                            tSDis = tDis;
                        }
                    }
                }
                
            }
        }

        return tUnit;
    }
}

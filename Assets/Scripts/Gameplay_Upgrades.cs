using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
///     Formules de scales à revoir     ###
/// </summary>

public class Gameplay_Upgrades : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    private TextMeshProUGUI _textMoney, _textCostDC, _textCostTV, _textCostIRR, _textCostIRV, _textCostIM, _textCostATS, _textCostATV;

    [SerializeField]
    private float _upgradeCostDC = 15, _upgradeCostTV, _upgradeCostIRR, _upgradeCostIRV, _upgradeCostIM, _upgradeCostATS, _upgradeCostATV;

    [SerializeField]
    private float _upgradeIndexDC = 1, _upgradeIndexTV = 1, _upgradeIndexIRR = 1, _upgradeIndexIRV = 1, _upgradeIndexIM = 1, _upgradeIndexATS = 1, _upgradeIndexATV = 1;

    public float money;

    ////////////////////////////////////////////////////////////////////////////////////
    
    private void Update()
    {
        _textMoney.text = "Money : " + money.ToString("F0") + "$";
        _textCostDC.text = _upgradeCostDC.ToString("F0") + "$";
        _textCostTV.text = _upgradeCostTV.ToString("F0") + "$";
        _textCostIRR.text = _upgradeCostIRR.ToString("F0") + "$";
        _textCostIRV.text = _upgradeCostIRV.ToString("F0") + "$";
        _textCostIM.text = _upgradeCostIM.ToString("F0") + "$";
        _textCostATS.text = _upgradeCostATS.ToString("F0") + "$";
        _textCostATV.text = _upgradeCostATV.ToString("F0") + "$";
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void UpgradeDoubleChances()
    {
        if (money >= _upgradeCostDC && Manager.Instance.gameplay_type.doubleChances <= 100)
        {
            _upgradeIndexDC++;
            money -= _upgradeCostDC;
            Manager.Instance.gameplay_type.doubleChances++;
        }
        
        if (Manager.Instance.gameplay_type.doubleChances > 100)
        {
            Manager.Instance.gameplay_type.doubleChances = 100;
        }
    }

    public void UpgradeTypeValue()
    {
        if (money >= _upgradeCostTV)
        {
            _upgradeIndexTV++;
            money -= _upgradeCostTV;
            Manager.Instance.gameplay_type.typeValue++;
            //_upgradeCostTV = (_upgradeCostTV + _upgradeIndexTV) * (Mathf.Pow(_upgradeIndexTV - 1, 1)) / 2;    ###

            _upgradeCostTV += _upgradeCostTV * 0.2f;

        }
    }
    public void UpgradeInkRegenRate()
    {
        if (money >= _upgradeCostIRR)
        {
            _upgradeIndexIRR++;
            money -= _upgradeCostIRR;
            Manager.Instance.gameplay_ink.inkRechargeRate *= 0.9f;
            //_upgradeCostIRR = (_upgradeCostIRR + _upgradeIndexIRR) * (Mathf.Pow(_upgradeIndexIRR - 1, 1)) / 2;    ###

            _upgradeCostIRR += _upgradeCostIRR * 0.2f;
        }
    }
    public void UpgradeInkRegenValue()
    {
        if (money >= _upgradeCostIRV)
        {
            _upgradeIndexIRV++;
            money -= _upgradeCostIRV;
            Manager.Instance.gameplay_ink.inkRechargeValue++;
            //_upgradeCostIRV = (_upgradeCostIRV + _upgradeIndexIRV) * (Mathf.Pow(_upgradeIndexIRV - 1, 1)) / 2;    ###

            _upgradeCostIRV += _upgradeCostIRV * 0.2f;
        }
    }
    public void UpgradeInkMax()
    {
        if (money >= _upgradeCostIM)
        {
            _upgradeIndexIM++;
            money -= _upgradeCostIM;
            Manager.Instance.gameplay_ink.inkMax++;
            //_upgradeCostIM = (_upgradeCostIM + _upgradeIndexIM) * (Mathf.Pow(_upgradeIndexIM - 1, 1)) / 2;    ###

            _upgradeCostIM += _upgradeCostIM * 0.2f;
        }
    }
    public void UpgradeAutoTypeSpeed()
    {
        if (money >= _upgradeCostATS)
        {
            _upgradeIndexATS++;
            money -= _upgradeCostATS;
            Manager.Instance.gameplay_type.autoTypeSpeed *= 0.9f;
            //_upgradeCostATS = (_upgradeCostATS + _upgradeIndexATS) * (Mathf.Pow(_upgradeIndexATS - 1, 1)) / 2;    ###

            _upgradeCostATS += _upgradeCostATS * 0.2f;
        }
    }
    public void UpgradeAutoTypeValue()
    {
        if (money >= _upgradeCostATV)
        {
            _upgradeIndexATV++;
            money -= _upgradeCostATV;
            Manager.Instance.gameplay_type.autoTypeValue++;
            //_upgradeCostATV = (_upgradeCostATV + _upgradeIndexATV) * (Mathf.Pow(_upgradeIndexATV - 1, 1)) / 2;    ###

            _upgradeCostATV += _upgradeCostATV * 0.2f;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////
}

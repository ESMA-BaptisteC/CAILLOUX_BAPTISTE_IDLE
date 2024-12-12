using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gameplay_Upgrades : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    private TextMeshProUGUI _textMoney, _textCostDC, _textCostTV, _textCostIRR, _textCostIRV, _textCostIM;

    [SerializeField]
    private float _upgradeCostDC = 15, _upgradeCostTV, _upgradeCostIRR, _upgradeCostIRV, _upgradeCostIM;

    public float money;

    ////////////////////////////////////////////////////////////////////////////////////
    
    private void Update()
    {
        _textMoney.text = "Money : " + money.ToString() + "$";
        _textCostDC.text = _upgradeCostDC.ToString() + "$";
        _textCostTV.text = _upgradeCostTV.ToString() + "$";
        _textCostIRR.text = _upgradeCostIRR.ToString() + "$";
        _textCostIRV.text = _upgradeCostIRV.ToString() + "$";
        _textCostIM.text = _upgradeCostIM.ToString() + "$";
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void UpgradeDoubleChances()
    {
        if (money >= _upgradeCostDC)
        {
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
            money -= _upgradeCostTV;
            Manager.Instance.gameplay_type.typeValue++;
        }
    }
    public void UpgradeInkRegenRate()
    {
        if (money >= _upgradeCostIRR)
        {
            money -= _upgradeCostIRR;
            Manager.Instance.gameplay_ink.inkRechargeRate *= 0.9f;
        }
    }
    public void UpgradeInkRegenValue()
    {
        if (money >= _upgradeCostIRV)
        {
            money -= _upgradeCostIRV;
            Manager.Instance.gameplay_ink.inkRechargeValue++;
        }
    }
    public void UpgradeInkMax()
    {
        if (money >= _upgradeCostIM)
        {
            money -= _upgradeCostIM;
            Manager.Instance.gameplay_ink.inkMax++;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////
}

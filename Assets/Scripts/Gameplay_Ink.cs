using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class Gameplay_Ink : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    private TextMeshProUGUI _textInkValue;

    [SerializeField]
    private Image _inkGauge;

    public float _inkCurrent;

    public float inkRechargeRate, inkRechargeValue, inkMax = 20;

    ////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        StartCoroutine(InkRecharge());

        _inkCurrent = inkMax;
    }

    void Update()
    {
        _inkGauge.fillAmount = _inkCurrent/inkMax;
        _textInkValue.text = _inkCurrent.ToString() + "/" + inkMax.ToString();
    }

    ////////////////////////////////////////////////////////////////////////////////////

    IEnumerator InkRecharge()
    {
        while (true)
        {
            if (_inkCurrent < inkMax)
            {
                yield return new WaitForSeconds(inkRechargeRate);

                _inkCurrent += inkRechargeValue;

                if (_inkCurrent >= inkMax)
                {
                    _inkCurrent = inkMax;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

}

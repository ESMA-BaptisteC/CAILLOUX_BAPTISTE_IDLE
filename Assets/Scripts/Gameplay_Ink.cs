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

    [SerializeField]
    private float _inkMax;
    public float _inkCurrent;

    [SerializeField]
    private float _inkRechargeRate, _inkRechargeValue;

    ////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        StartCoroutine(InkRecharge());

        _inkCurrent = _inkMax;
    }

    void Update()
    {
        _inkGauge.fillAmount = _inkCurrent/_inkMax;
        _textInkValue.text = _inkCurrent.ToString() + "/" + _inkMax.ToString();
    }

    ////////////////////////////////////////////////////////////////////////////////////

    IEnumerator InkRecharge()
    {
        while (true)
        {
            if (_inkCurrent < _inkMax)
            {
                yield return new WaitForSeconds(_inkRechargeRate);

                _inkCurrent += _inkRechargeValue;

                if (_inkCurrent >= _inkMax)
                {
                    _inkCurrent = _inkMax;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

}

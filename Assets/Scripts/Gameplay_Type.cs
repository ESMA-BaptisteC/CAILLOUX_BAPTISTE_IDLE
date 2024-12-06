using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Gameplay_Type : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    private TextMeshProUGUI _textDoubleChances, _textMain, _textMoney, _textPageCount,
        _textUpgradeCostDoubleChances;

    [SerializeField]
    private int _currentWords, _maxWords, _currentPages, _maxPages, _books;
    [SerializeField]
    private int _typeValue = 1, _doubleChances;

    [SerializeField]
    private float _money, _upgradeCost = 15;

    [SerializeField]
    private string _displayText;

    [SerializeField]
    public bool isAutoTypeOn;

    ////////////////////////////////////////////////////////////////////////////////////

    private void Start()
    {
        _maxWords = Random.Range(50, 100);
        _maxPages = Random.Range(10, 50);

        StartCoroutine(AutoType(.5f));
    }

    private void Update()
    {
        _textDoubleChances.text = "Double chances : " + _doubleChances.ToString() + "%";
        _textMoney.text = "Money : " + _money.ToString() + "$";
        _textPageCount.text = _currentPages.ToString() + " / " + _maxPages.ToString();
        _textUpgradeCostDoubleChances.text = _upgradeCost.ToString() + "$";
        _textMain.text = _displayText;

        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && Manager.Instance.gameplay_ink._inkCurrent >= _typeValue)
        {
            Type(_typeValue);
        }

        if (_currentWords >= _maxWords)
        {
            NewPage();
        }

        if (_currentPages >= _maxPages)
        {
            NewBook();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void Type(int value)
    {
        Manager.Instance.gameplay_ink._inkCurrent -= value;
        _currentWords += value;
        _displayText += Manager.Instance.word_randomiser.GetRandomWord() + " ";
        DoubleChances(value);
    }

    IEnumerator AutoType(float waitTime)
    {
        while (true)
        {
            if (isAutoTypeOn)
            {
                yield return new WaitForSeconds(waitTime);

                Type(1);
            }

            yield return new WaitForEndOfFrame();
        }
    }
    public void SwitchAutoType()
    {
        isAutoTypeOn = !isAutoTypeOn;
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void UpgradeDoubleChances()
    {
        if (_money >= _upgradeCost)
        {
            _money -= _upgradeCost;
            _doubleChances++;
        }

        if (_doubleChances > 100)
        {
            _doubleChances = 100;
        }
    }

    private void DoubleChances(int value)
    {
        int tempValue = Random.Range(0, 100);
        if (tempValue <= _doubleChances)
        {
            _currentWords += value;
            _displayText += Manager.Instance.word_randomiser.GetRandomWord() + " ";
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void NewBook()
    {
        _money += 100000;
        _books++;
        _currentPages = 0;
        _maxPages = Random.Range(10, 50);
    }

    private void NewPage()
    {
        _money += 10;
        _currentPages++;
        _currentWords = 0;
        _maxWords = Random.Range(50, 100);
        _displayText = string.Empty;
    }

    ////////////////////////////////////////////////////////////////////////////////////
}

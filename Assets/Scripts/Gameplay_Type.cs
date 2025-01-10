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
    private TextMeshProUGUI _textDoubleChances, _textMain, _textPageCount;

    [SerializeField]
    private int _currentWords, _maxWords, _currentPages, _maxPages, _books;

    [SerializeField]
    private string _displayText;

    ////////////////////////////////////////////////////////////////////////////////////
    
    public bool isAutoTypeOn;
    public float doubleChances;
    public int typeValue = 1;
    public int autoTypeValue = 1;
    public float autoTypeSpeed = 1;

    ////////////////////////////////////////////////////////////////////////////////////

    private void Start()
    {
        _maxWords = Random.Range(50, 65);
        _maxPages = Random.Range(10, 50);

        StartCoroutine(AutoType());
    }

    private void Update()
    {
        _textDoubleChances.text = "Double chances : " + doubleChances.ToString() + "%";
        _textPageCount.text = _currentPages.ToString() + " / " + _maxPages.ToString();
        _textMain.text = _displayText;

        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && Manager.Instance.gameplay_ink._inkCurrent >= typeValue)
        {
            Type(typeValue);
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

        for (var i = 0; i < value; i++)
        {
            string temp = Manager.Instance.word_randomiser.GetRandomWord();
            temp = temp.Replace("\r", "");
            _displayText += temp + " ";
        }
        DoubleChances(value);
    }

    IEnumerator AutoType()
    {
        while (true)
        {
            if (isAutoTypeOn)
            {
                yield return new WaitForSeconds(autoTypeSpeed);

                if (Manager.Instance.gameplay_ink._inkCurrent >= autoTypeValue)
                {
                    Type(autoTypeValue);
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
    public void SwitchAutoType()
    {
        isAutoTypeOn = !isAutoTypeOn;
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void DoubleChances(int value)
    {
        int tempValue = Random.Range(0, 100);
        if (tempValue <= doubleChances)
        {
            _currentWords += value;

            for (var i = 0; i < value; i++)
            {
                string temp = Manager.Instance.word_randomiser.GetRandomWord();
                temp = temp.Replace("\r", "");
                _displayText += temp + " ";
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void NewBook()
    {
        Manager.Instance.gameplay_upgrades.money += 100000;
        _books++;
        _currentPages = 0;
        _maxPages = Random.Range(10, 50);
    }

    private void NewPage()
    {
        Manager.Instance.gameplay_upgrades.money += 10;
        _currentPages++;
        _currentWords = 0;
        _maxWords = Random.Range(50, 65);
        _displayText = string.Empty;
    }

    ////////////////////////////////////////////////////////////////////////////////////
}

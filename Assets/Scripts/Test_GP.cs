using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Test_GP : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textDoubleChances;
    
    [SerializeField]
    private int _currentWords, _maxWords, _currentPages, _maxPages, _books;

    [SerializeField]
    private int  _typeValue = 1, _doubleChances;


    private void Start()
    {
        _maxWords = Random.Range(10, 100);
        _maxPages = Random.Range(10, 100);
    }

    private void Update()
    {
        _textDoubleChances.text = _doubleChances.ToString();

        Type(_typeValue);

        if (_currentWords >= _maxWords)
        {
            NewPage();
        }

        if (_currentPages >= _maxPages)
        {
            NewBook();
        }
    }

    private void Type(int value)
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
        {
            _currentWords += value;

            DoubleChances(value);
        }
    }


    public void UpgradeDoubleChances()
    {
        _doubleChances++;
    }

    private void DoubleChances(int value)
    {
        int tempValue = Random.Range(0, 100);
        if (tempValue <= _doubleChances)
        {
            _currentWords += value;
        }
    }

    private void NewBook()
    {
        _books++;
        _currentPages = 0;
        _maxPages = Random.Range(10, 100);
    }

    private void NewPage()
    {
        _currentPages++;
        _currentWords = 0;
        _maxWords = Random.Range(10, 100);
    }
}

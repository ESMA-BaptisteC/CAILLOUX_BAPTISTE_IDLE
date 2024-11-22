using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GP : MonoBehaviour
{
    [SerializeField]
    private int _wordsWritten, _maxWords, _score;
    [SerializeField]
    private int  _typeValue = 1, _doubleChances;


    private void Start()
    {
        _maxWords = Random.Range(10, 100);
    }

    private void Update()
    {


        Type(_typeValue);

        if (_wordsWritten >= _maxWords)
        {
            NewPage();
        }
    }

    private void Type(int value)
    {
        if (Input.anyKeyDown)
        {
            _wordsWritten += value;

            int tempValue = Random.Range(0, 100);
            if (tempValue <= _doubleChances)
            {
                _wordsWritten += value;
            }
        }
    }

    private void NewPage()
    {
        _score++;
        _wordsWritten = 0;
        _maxWords = Random.Range(10, 100);
    }

    public void UpgradeDoubleChances()
    {
        _doubleChances++;
    }

}

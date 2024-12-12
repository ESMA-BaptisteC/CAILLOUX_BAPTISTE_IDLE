using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class WordRandomiser : MonoBehaviour
{
    public TextAsset textFile;

    public string[] _words;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        var x = Regex.Split(textFile.text, ((char)10).ToString());
        _words = x;
    }
    public string GetRandomWord()
    {
        return _words[Random.Range(0,_words.Length)];
    }
}

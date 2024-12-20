using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class WordRandomiser : MonoBehaviour
{
    public List<TextAsset> textFiles;

    public List<string[]> _words;


    private void Start()
    {
        _words = new List<string[]>();
        Init();
    }

    private void Init()
    {
        _words.Clear();
        for (int i = 0; i < textFiles.Count; i++)
        {
            var temp = new string[] { };
            var x = Regex.Split(textFiles[i].text, ((char)10).ToString());
            temp = x;
            _words.Add(temp);
        }
    }
    public string GetRandomWord()
    {
        var index = Random.Range(0, _words.Count);
        var indexSquare = Random.Range(0, _words[index].Length);
        return _words[index][indexSquare];
    }

    public void AddTextFile(TextAsset textFile)
    {
        textFiles.Add(textFile);
        Init();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_wordPack", menuName = "Word Pack", order = 0)]

public class SO_WordPack : ScriptableObject
{
    public string title;
    public float cost;
    public float value;
    public TextAsset words;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Manager : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////

    public static Manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public Gameplay_Type gameplay_type;
    public Gameplay_Ink gameplay_ink;
    public Gameplay_Upgrades gameplay_upgrades;
    public WordRandomiser word_randomiser;

    ////////////////////////////////////////////////////////////////////////////////////

}

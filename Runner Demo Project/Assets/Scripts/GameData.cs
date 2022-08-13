using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class GameData : ScriptableObject
{
    public bool paintPhase = false;
    public bool gameStarted = false;

}

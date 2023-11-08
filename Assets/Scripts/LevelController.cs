using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Corrida/LevelConfiguration", order = 1)]
public class LevelController : ScriptableObject
{
    public float speed;
    public int minScore;
}

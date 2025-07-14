using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyWaveData", menuName ="ScriptableObject/EnemyWaveData")]
public class EnemyWaveData : ScriptableObject
{
    public EnemyWave[] waves;
}
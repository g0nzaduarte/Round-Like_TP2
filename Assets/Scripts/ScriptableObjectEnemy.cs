using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySharedData", menuName = "ScriptableObjects/EnemySharedData", order = 1)]
public class EnemySharedData : ScriptableObject
{
    public float moveSpeed = 2f;
    public float chaseRange = 5f;
}

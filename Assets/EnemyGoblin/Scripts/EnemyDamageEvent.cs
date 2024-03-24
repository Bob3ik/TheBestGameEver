using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageEvent : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;

    public void AttackDamageEvent()
    {
        _enemyAI.AttackDamage();
    }
}

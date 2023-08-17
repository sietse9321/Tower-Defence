using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float hp = 4;
    public int moneyToGive;
    [SerializeField] PlayerStats pStats;
    void Update()
    {
        if(hp <= 0)
        {
            pStats = FindObjectOfType<PlayerStats>();
            pStats.money += moneyToGive;
            Destroy(gameObject);
        }
    }
}

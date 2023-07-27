using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float hp = 4;
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

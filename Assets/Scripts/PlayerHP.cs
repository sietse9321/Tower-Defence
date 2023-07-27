using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float pHp;
    [SerializeField]EnemyHp enemyHp;
    void Start()
    {
        //sets the player hp to 200
        pHp = 200f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyHp = other.GetComponent<EnemyHp>();
            pHp -= enemyHp.hp;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        print(pHp);
    }
}

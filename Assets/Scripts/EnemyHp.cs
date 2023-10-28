using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float hp = 4;
    public int moneyToGive;
    [SerializeField] PlayerStats pStats;
    [SerializeField] Wall wall;
    void Update()
    {
        if(hp <= 0)
        {
            pStats = FindObjectOfType<PlayerStats>();
            pStats.money += moneyToGive;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);

        if(collision.gameObject.tag == "Wall")
        {
            collision.gameObject.GetComponent<Wall>().wallHp--;
        }
    }
}

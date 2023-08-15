using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float pHp;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI moneyText;
    EnemyHp enemyHp;
    public int money = 300;

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
    void Update()
    {
        hpText.text = $"Hp: {pHp}";
        moneyText.text = $"Money: {money}";

    }
}

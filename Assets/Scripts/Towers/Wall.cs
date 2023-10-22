using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int wallHp = 3;

    private void OnTriggerEnter(Collider other)
    {
        wallHp--;
    }
    private void Update()
    {
        if (wallHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}


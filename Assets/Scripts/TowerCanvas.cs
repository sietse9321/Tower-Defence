using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCanvas : MonoBehaviour
{
    public GameObject partTortate;
    TowerBehavior tBehavior;
    // Start is called before the first frame update
    void Start()
    {
        tBehavior = GetComponentInParent<TowerBehavior>();
        GetComponent<Canvas>().worldCamera = Camera.main;
        transform.SetParent(partTortate.transform);
    }

    // Update is called once per frame
    void Update()
    {

        partTortate.transform.LookAt(Camera.main.transform.position);
    }
    /// <summary>
    /// upgrades the firerate by 2 and prints the current tower firerate
    /// </summary>
    public void FireRateUpgrade()
    {
        tBehavior.fireRate += 2;
        print("Upgrading firerate to" + tBehavior.fireRate);
    }
    /// <summary>
    /// upgrades the bullet damage by 1 and prints the new tower damage
    /// </summary>
    public void DamageUpgrade()
    {
        tBehavior.bulletDamage++;
        print("Upgrading damage to" + tBehavior.bulletDamage);

    }
    /// <summary>
    /// upgrades the range by 2 and prints the with the value of the range
    /// </summary>
    public void RangeUpgrade()
    {
        tBehavior.range += 2;
        print("Upgrading range to" + tBehavior.range);
    }
}

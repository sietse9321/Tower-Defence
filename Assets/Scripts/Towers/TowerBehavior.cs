using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class TowerBehavior : MonoBehaviour
{
    public float range = 5f;
    private float timeBetweenShot = 1f;
    public float fireRate = 1f;
    public float turnspeed = 20f;
    public float bulletDamage = 1;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    private Transform target;
    public Transform firePoint;
    public Transform partToRotate;
    public string enemyTag = "Enemy";
    public string towerTargeting = "First";
    bool targetFirstEnemy = true;


    // Start is called before the first frame update
    void Start()
    {
        //repeats a method over time with a repeat rate
        InvokeRepeating("TargetUpdate", 0f, 0.5f);
    }

    // Update is called once per frame
    //rotates turret and shiz
    void Update()
    {
        //if there is no target return
        if (target == null) return;
        //direction is target position minus the transform position
        Vector3 direction = target.position - transform.position;
        //rotation = lookrotation using direction
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        //rotation is from point a to b but very smooth (a)           (b)           (t)           (speed)  gets/sets rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        //tranform rotation is rotation using    x       y        z
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //if time is smaller or equal to 0 do code
        if (timeBetweenShot <= 0f)
        {
            //calls method
            Shoot();
            //sets the new time 
            timeBetweenShot = 1f / fireRate;
        }
        //lowers the time by time
        timeBetweenShot -= Time.deltaTime;

    }



    void Shoot()
    {
        print("target aquired shooting now");
        //instantia bullet
        //gameobject bullet is a new instance of the bullet prefab instantiated at firepoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject wip = Instantiate(muzzleFlash, firePoint);
        Destroy(wip, 2f);

        Bullet bulletComponet = bullet.GetComponent<Bullet>();
        //if bullet is not null do code
        if (bulletComponet != null)
        {
            bulletComponet.Seek(target);
            //bullet damage is this scripts bullet damage
            bulletComponet.damage = bulletDamage;
        }
    }




    void TargetUpdate()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject targetEnemy = null;

        // Add this boolean variable, true for targeting the first enemy, false for targeting the last enemy

        if (targetFirstEnemy && enemies.Length > 0)
        {
            targetEnemy = enemies[0];
        }
        else if (!targetFirstEnemy && enemies.Length > 0)
        {
            targetEnemy = enemies[enemies.Length - 1];
        }

        if (targetEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.transform.position);

            if (distanceToEnemy > range)
            {
                // If the target enemy is out of range, find the next enemy in the array within range
                targetEnemy = null;

                for (int i = 0; i < enemies.Length; i++)
                {
                    distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);
                    if (distanceToEnemy <= range)
                    {
                        targetEnemy = enemies[i];
                        break;
                    }
                }
            }
        }

        if (targetEnemy != null)
        {
            target = targetEnemy.transform;
        }
        else
        {
            target = null; // No enemies found within range, set target to null
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
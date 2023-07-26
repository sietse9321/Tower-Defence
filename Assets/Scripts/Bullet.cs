using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] Transform target;
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float bulletTime = 1.5f;
    public float damage;
    EnemyHp eHp = null;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        //gets rigid body from this object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves the rigidbody up times the bullet speed
        rb.velocity = transform.forward * bulletSpeed;
        if (target != null)
        {
            rb.transform.LookAt(target.transform.position);

        }

        //destoys this gameobject after and uses bullet time for this
        Destroy(gameObject, bulletTime);
        // !!!!!!!!!transform.LookAt();!!!!!!!!!!!!

    }


    private void OnTriggerEnter(Collider other)
    {
        //if the trigger enter tag is Enemy do code
        if (other.CompareTag("Enemy"))
        {
            //enemyhp is collision objects component
            eHp = other.GetComponent<EnemyHp>();
            //lowers hp from enemyHp script equal to the damage of the bullet
            eHp.hp -= damage;
            //destroys the bullet (this) gameobject
            Destroy(this.gameObject);
        }
    }
}

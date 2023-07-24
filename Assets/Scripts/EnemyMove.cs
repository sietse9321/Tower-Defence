using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public NavMeshAgent agent;
    public GameObject endGO;
    public Transform endT;
    // Start is called before the first frame update
    void Start()
    {
        //gets the component
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        //find gameobject
        endGO = GameObject.Find("END");
        //gets the transform from the gameobject
        endT = endGO.GetComponent<Transform>();
        //sets the destination for the agent (uses the tranform of the "EndGo")
        agent.SetDestination(endGO.transform.position);
    }
}

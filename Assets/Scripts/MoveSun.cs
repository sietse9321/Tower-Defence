using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveSun : MonoBehaviour
{
    [SerializeField] Transform sun;
    [SerializeField] float rotationSpeed = 1.0f;
    // Update is called once per frame
    void Start()
    {
        //gets the transform from this object
        sun = GetComponent<Transform>();        
    }

    void Update()
    {
        //rotates the sun transform up with the speed of rotation speed times time
        sun.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTower : MonoBehaviour
{
    float range = 2.5f;
    float rayAngle = 30f;
    [SerializeField] Animator printerAnimator;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] bool placedWall = false;
    void Update()
    {
        printerAnimator.SetBool("PlayAnimation", true);
        if(placedWall == false)
        {
            print("placing");
            PlaceWall();
        }
    }
    
    void PlaceWall()
    {
        //loop through each angle from 0 to 360
        for (float angle = 0; angle < 360; angle += rayAngle)
        {
            //create a rotation based on the angle (20 degrees in x, angle in y)
            Quaternion rayRotation = Quaternion.Euler(20, angle, 0);
            //calculate the direction of the ray based on the rotation
            Vector3 rayDirection = rayRotation * Vector3.forward;

            Debug.DrawRay(new Vector3(transform.position.x, 1f, transform.position.z), rayDirection * range, Color.green);

            if (Physics.Raycast(new Vector3(transform.position.x, 1f, transform.position.z), rayDirection, out RaycastHit hit, range))
            {
                //check if the hit object has a "Road" tag
                if (hit.collider.tag == "Road")
                {
                    //calculate the midpoint of the road using the collider bounds
                    Bounds roadBounds = hit.collider.bounds;
                    Vector3 roadCenter = roadBounds.center;
                    //place the wall at the center of the road
                    Instantiate(wallPrefab, new Vector3(roadCenter.x, 1f, roadCenter.z), Quaternion.Euler(-90f, 0f, 0f));
                    //set a bool (presumably to indicate that a wall was placed)
                    placedWall = true;
                    //exit loop
                    printerAnimator.SetBool("PlayAnimation",false);
                    break;
                }
            }
        }
    }
    
    private void Start()
    {
        printerAnimator = GetComponent<Animator>();
    }
}

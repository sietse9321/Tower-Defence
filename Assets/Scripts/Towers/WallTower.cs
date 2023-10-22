using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTower : MonoBehaviour
{
    float range = 2.5f;
    float rayAngle = 20f;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] bool placedWall = false;
    void Update()
    {
        if(placedWall == false)
        {
            print("placing");
            PlaceWall();
        }
    }
    
    void PlaceWall()
    {
        //does code for every angle until the angel is 360
        for(float angle = 0; angle < 360; angle += rayAngle)
        {
            //sets the rayrotation using x rotation at 20 degrees and y rotation "angle"
            Quaternion rayRotation = Quaternion.Euler(20, angle, 0);
            //sets direction of the ray using quaternion and forwards
            Vector3 rayDirection = rayRotation * Vector3.forward;
            //draws a debug ray
            //puts info in hit if the ray hits
            Debug.DrawRay(transform.position, rayDirection * range, Color.green);
            if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, range))
            {
                //check if the rays hitcollider tag is Road
                if (hit.collider.tag == "Road")
                {
                    //places a wall where the hit was detected
                    Vector3 wallPosition = hit.point + new Vector3(0.4f,0.5f,-0.3f);
                    //prefab, the position, rotation, parent
                    Instantiate(wallPrefab, wallPosition, Quaternion.identity);
                    //set bool
                    placedWall = true;
                    //breaks for loop
                    break;
                }
            }
        }
    }
}

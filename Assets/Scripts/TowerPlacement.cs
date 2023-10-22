using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    string[] cantPlaceTags = { "Road", "BossRoad" };
    [SerializeField] Camera _camera;
    private GameObject currentTower;
    [SerializeField] GameObject _tower;
    bool firstPress = false;
    PlayerStats playerStats;
    // Start is called before the first frame update

    private void Start()
    {
        GameObject ps = GameObject.FindWithTag("End");
        playerStats = ps.GetComponent<PlayerStats>();

    }
    void Update()
    {
        //if (1) is pressed down do code
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //if equal to false
            if (firstPress == false)
            {
                //calls method with prefab tower
                SetTowerToPlace(_tower);
                //sets bool to true
                firstPress = true;
            }
            else
            {
                firstPress = false;
                //destroys gameobject
                Destroy(currentTower);
            }
        }
        //if not null do code
        if (currentTower != null)
        {
            //shoots a ray using the camera where the mouse position is used to shoot the ray too 
            Ray camRay = _camera.ScreenPointToRay(Input.mousePosition);
            //if raycast         ray       raycast object       distance
            if (Physics.Raycast(camRay, out RaycastHit hitInfo, 100f))
            {
                //gameobject transform position is raycast hit point
                currentTower.transform.position = hitInfo.point;
            }
            //if leftmoouse button down and not raycast does not hit object with tag road do code
            if (Input.GetMouseButtonDown(0) && !cantPlaceTags.Contains(hitInfo.collider.tag) && playerStats.money >= 150)
            {
                firstPress = false;
                currentTower = null;
                playerStats.money -= 150;
            }
        }
    }

    /// <summary>
    /// current tower is instantiate using gameboject position and rotation
    /// </summary>
    /// <param name="tower"></param>
    public void SetTowerToPlace(GameObject tower)
    {
        currentTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}

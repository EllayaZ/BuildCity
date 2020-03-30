using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing_houses : MonoBehaviour
{
    public GameObject [] prefabs;
    public Camera mainCamera;
    public Vector3 offset;
    private int indexForBuilding = -1;

    private GameObject SpawnHandler;

    private void Awake()
    {
        SpawnHandler = GameObject.FindWithTag("Spawn_Handler");
    
    
    }
    
    private void Update()
    {


        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        
       
        //check if the user  make a click
        if (Input.GetMouseButtonDown(0))
        {
            //check if the ray colides with something
            if (hit.collider != null)
            {
                if (indexForBuilding >= 0)
                {
                    GameObject items = prefabs[indexForBuilding];

                    Vector3 position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));

                    Instantiate(items, position + offset, Quaternion.identity);
                    SpawnHandler.GetComponent<SpawnSystem>().buildingPositions.Add(position);

                }


            }

        }

        //i wanted to make this options, and rotate my objects but it did not work

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("K");
            russian_house.transform.Rotate(Vector3.up, -10, Space.World);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            russian_house.transform.Rotate(Vector3.up, 2, Space.World);

        }*/


    }

    public void SetIndexForBuilding(int indexForBuilding)
    {
        this.indexForBuilding = indexForBuilding;
    
    
    }

}

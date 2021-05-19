using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBuildingSystem : MonoBehaviour
{
    public Transform ObjToMove;
    public GameObject ObjToPlace;
    public LayerMask mask;

    int LastPosX, LastPosY, LastPosZ;
    Vector3 mousePos;

    public int width, height;
    Grid placementGrid;

    private void Start()
    {
        placementGrid = new Grid(width, height);
    }


    void Update()
    {
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            int PosX = (int)Mathf.Round(hit.point.x);
            int PosY = (int)Mathf.Round(hit.point.y);
            int PosZ = (int)Mathf.Round(hit.point.z);

            //Debug.Log("X : " + PosX + "& Z : " + PosZ);
            if (PosX != LastPosX || PosY != LastPosY || PosZ != LastPosZ)
            {
                LastPosX = PosX;
                LastPosY = PosY;
                LastPosZ = PosZ;


                ObjToMove.position = new Vector3(PosX, PosY+0.5f, PosZ) ;
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(ObjToMove.position);
                
                if(ObjToMove.position.y+0.5>placementGrid[(int)ObjToMove.transform.position.x,(int)ObjToMove.transform.position.z])
                {
                    Instantiate(ObjToPlace, ObjToMove.position, Quaternion.identity);
                    placementGrid[(int)ObjToMove.transform.position.x,(int)ObjToMove.transform.position.z] += 1;
                    Debug.Log((int)ObjToMove.transform.position.x+","+((int)ObjToMove.transform.position.z)+"="+placementGrid[(int)ObjToMove.transform.position.x,(int)ObjToMove.transform.position.z]);
                }
                
                
            }
            
        }
    }
}

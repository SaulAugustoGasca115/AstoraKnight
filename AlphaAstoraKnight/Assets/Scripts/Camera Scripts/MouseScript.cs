using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    [Header("Own Mouse Cursor")]
    public Texture2D cursorText;
    public GameObject mousePoint;
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;
    private GameObject instantiatedMouse;
     

   

    // Update is called once per frame
    void Update()
    {
        //Cursor.SetCursor(cursorText,hotSpot,cursorMode);
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    Vector3 temporalPosition = hit.point;
                    temporalPosition.y = 0.15f;

                    //Instantiate(mousePoint,temporalPosition,Quaternion.identity);

                    if(instantiatedMouse == null)
                    {
                        //instantiatedMouse = Instantiate(mousePoint,temporalPosition,Quaternion.identity) as GameObject;
                        instantiatedMouse = Instantiate(mousePoint) as GameObject;
                        instantiatedMouse.transform.position = temporalPosition;
                    }
                    else
                    {
                        Destroy(instantiatedMouse);
                        instantiatedMouse = Instantiate(mousePoint) as GameObject;
                        instantiatedMouse.transform.position = temporalPosition;
                    }

                }
            }
        }
    }
}

using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Drag : MonoBehaviour

{

    private Vector3 mOffset;
    private float yValue = 3.8f;


    private float mZCoord;



    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;




        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag(){
        Vector3 pos = GetMouseAsWorldPoint();
        yValue += Input.mouseScrollDelta.y * 1f;

        if (yValue < 3.8f){
            yValue = 3.8f;
        }

        pos.y = yValue;
        transform.position = pos + mOffset;

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up, 2f);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up, -2f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right, 2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right, -2f);
        }
        
    }

}
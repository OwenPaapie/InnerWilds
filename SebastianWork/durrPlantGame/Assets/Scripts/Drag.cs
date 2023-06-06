using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Drag : MonoBehaviour

{
    [SerializeField] private GameObject player;
    private Vector3 mOffset;
    private float yValue = 5f;
    public bool isDragging = false;

    private float mZCoord;



    void OnMouseDown()

    {
        isDragging = true;
        /*var rot = transform.rotation;
        rot.y = 0f;*/
        /* if (!player.activeSelf)
             transform.rotation = rot *  Quaternion.Euler(0f, 0f, 0f);*/
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        yValue = GetMouseAsWorldPoint().y;


        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        isDragging = false;
        gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
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
        if (!player.activeSelf) {
            Vector3 pos = GetMouseAsWorldPoint();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            yValue += Input.mouseScrollDelta.y * 1f;

            if (yValue < 5f)
            {
                yValue = 5f;
            }

            pos.y = yValue;
            transform.position = pos + mOffset;

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0,1,0), Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, -1, 0), Space.World);
            }
            /*if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.right, 2f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.right, -2f);
            }*/

        }
    }
}
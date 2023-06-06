using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBridgePhysicsScript : MonoBehaviour
{

    [SerializeField] Transform respawn;
    [SerializeField] GameObject player;
    private Vector3 lastPos;
    private bool moving=false;
    [SerializeField] private Drag drag;
    // Start is called before the first frame update
    void Start(){
        lastPos = transform.position;
        drag = GetComponent<Drag>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = transform.position - lastPos;
        lastPos = transform.position;

        if (displacement.magnitude > 0.001f){ // return true if char moved 1mm
            moving = true;
        }
        else{
            moving = false;
        }
        if (transform.position.y <= -30f) {
            transform.position = respawn.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        GetComponent<Rigidbody>().detectCollisions = true;
     //   gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
    }
    /*void OnCollisionStay(Collision target)
    {
        if (target.gameObject.tag.Equals("water") == true){
            transform.position = respawn.position;
        }
        if (((target.gameObject.tag.Equals("terrain") && !moving) || (target.gameObject.tag.Equals("Player")))){
            //  
            if (player.activeSelf == true){
                gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void OnCollisionExit(Collision target){
        if (!target.gameObject.tag.Equals("Player") && (target.gameObject.tag.Equals("terrain") && !moving))
        {
            gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }*/
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag.Equals("water") == true){
            transform.position = respawn.position;
        }
        if (!drag.isDragging){
            //Debug.Log(col.gameObject.tag.Equals("terrain") && !moving);
            if ((col.gameObject.tag.Equals("terrain") && !moving))
                gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        }

        //if (col.gameObject.tag == "Player")
        //{
        //    gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        //}
    }

    void OnCollisionExit(Collision col)
    {
       /* if (drag.isDragging){
            Debug.Log(!(col.gameObject.tag.Equals("terrain")));
            if (!(col.gameObject.tag.Equals("terrain"))) {
              */ // gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
       /*     }
        }*/
    }
}

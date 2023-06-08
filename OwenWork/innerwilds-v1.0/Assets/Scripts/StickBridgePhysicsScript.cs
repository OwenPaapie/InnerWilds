using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBridgePhysicsScript : MonoBehaviour
{

    [SerializeField] Transform respawn;
    private Vector3 lastPos;
    private bool moving=false;
    // Start is called before the first frame update
    void Start(){
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var displacement = transform.position - lastPos;
        lastPos = transform.position;

        if (displacement.magnitude > 0.001){ // return true if char moved 1mm{
            moving = true;
        }
        else{
            moving = false;
        }
        gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
    }
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag.Equals("water") == true){
            transform.position = respawn.position;
        }
        if (target.gameObject.tag.Equals("terrain") == true && moving){
            gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;

        }
    }
}

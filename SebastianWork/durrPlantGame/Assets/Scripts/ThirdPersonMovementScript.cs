using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public GameObject child;
    public GameObject player;
    public float speed = 12f;
    private float turnSmoothSpeed;
    private float turnSmoothTime = 0.1f;
    private float gravity = 0f;
    public CinemachineFreeLook cinemachineFreeLook;

    // Update is called once per frame
    void Update(){
        float horAx = Input.GetAxisRaw("Horizontal");
        float verAx = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horAx, 0f, verAx).normalized;
        gravity -= 9.81f * Time.deltaTime;
        controller.Move(new Vector3(0f, gravity, 0f));
        if (controller.isGrounded) {
            gravity += 0f;
            Vector3 v = child.transform.position;
            v.y = controller.transform.position.y -2.6f;
            child.transform.position = v;
            /*if (Input.GetKey(KeyCode.Space)) {
                gravity = +0.306f;
            }*/
        } 

        if (dir.magnitude >= 1f){
            float tarAng = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cinemachineFreeLook.m_XAxis.Value;
            float ang = Mathf.SmoothDampAngle(child.transform.eulerAngles.y, tarAng, ref turnSmoothSpeed, turnSmoothTime);
            child.transform.rotation = Quaternion.Euler(0f, ang, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, tarAng, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }
    }

    private void Awake(){
        //Cursor.visible = false;
    }
}

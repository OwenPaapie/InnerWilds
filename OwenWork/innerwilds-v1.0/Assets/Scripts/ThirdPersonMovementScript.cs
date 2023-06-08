using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    private float turnSmoothSpeed;
    private float turnSmoothTime = 0.1f;
    private float gravity = 0f;
    // Update is called once per frame
    void Update(){
        float horAx = Input.GetAxisRaw("Horizontal");
        float verAx = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horAx, 0f, verAx).normalized;
        gravity -= 9.81f * Time.deltaTime;
        controller.Move(new Vector3(0f, gravity, 0f));
        if (controller.isGrounded) {
            gravity = 0;
            /*if (Input.GetKey(KeyCode.Space)) {
                gravity = +0.306f;
            }*/
        } 

        if (dir.magnitude >= 0.1f){
            float tarAng = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float ang = Mathf.SmoothDampAngle(transform.eulerAngles.y, tarAng, ref turnSmoothSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, ang, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, tarAng, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    private void Awake(){
        Cursor.visible = false;
    }
}

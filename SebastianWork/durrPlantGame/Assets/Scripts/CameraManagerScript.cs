using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.E)){
            player.SetActive(true);
            gameObject.SetActive(false);
        } if (gameObject.activeSelf) {
            player.SetActive(false);
        }
    }

    private void Awake(){
        Cursor.visible = true;
        player.SetActive(false);
    }
}

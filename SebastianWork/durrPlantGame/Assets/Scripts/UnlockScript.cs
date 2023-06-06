using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> InteractiveObj; // list of locked areas
    [SerializeField] private bool interactWithE;

    private void OnTriggerStay(Collider Other) {
        // selects player
        if (Other.tag == "Player") {
            //Removes all the obstacles in the list
            try{
                if ((interactWithE && Input.GetKey(KeyCode.E)) || !interactWithE) {
                    for (int i = 0; i < InteractiveObj.Count; i++){
                        InteractiveObj[i].GetComponent<InteractiveScript>().isInteractable = true;
                    }
                    // destroys the trigger
                    Destroy(this.transform.gameObject);
                }
            } catch {
                Debug.Log("Missing Component InteractableScript");
            }
        }
    }
    // Start is called before the first frame update
}

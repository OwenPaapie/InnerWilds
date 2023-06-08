using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> InteractiveObj; // list of locked areas

    private void OnTriggerEnter(Collider Other) {
        // selects player
        if (Other.tag == "Player") {
            //Removes all the obstacles in the list
            try{
                for (int i = 0; i < InteractiveObj.Count; i++) {
                    InteractiveObj[i].GetComponent<InteractiveScript>().isInteractable = true;
                }
            } catch {
                Debug.Log("Missing Component InteractableScript");
            }
            // destroys the trigger
            Destroy(this.transform.gameObject);
        }
    }
    // Start is called before the first frame update
}

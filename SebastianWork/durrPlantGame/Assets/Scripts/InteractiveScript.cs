using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveScript : MonoBehaviour
{
    public bool isInteractable; // checks if object is in the right state to be interactable
    public bool spotted = false; // checks if player is in range
    [SerializeField] private bool isAutomatic = false; // checks if the interaction is by the player or it's automatic
    [SerializeField] private string functionality;
    [SerializeField] private bool automaticOff;

    // Update is called once per frame
    void Update()
    {
        if (isInteractable && ((spotted && Input.GetKey(KeyCode.E)) || isAutomatic)){
            switch (functionality) {
                case "Child":
                    unlockChild();
                break;
                case "Stick":
                    unlockStick();
                break;
            }
            if (automaticOff) {
                isInteractable = false;
            }
        }
    }

    private void unlockChild() {
        foreach (Transform child in this.transform)
        {    // unlocks all the children of the object that this script is attached to
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
        //isInteractable = !isInteractable; // resets the Interactibility
    }

    private void unlockStick() {
        try {
            GameObject spawn = GameObject.Find("RespawnStick");
            transform.position = spawn.transform.position;
        }
        catch {
            Debug.Log("Missing object called RespawnStick");
        }
    }
}

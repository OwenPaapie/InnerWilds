using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject menu;
    private float timer=0.5f;
    private void Update(){
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                player.SetActive(!player.activeSelf);
                menu.SetActive(!menu.activeSelf);
                timer = 0.5f;
            }
        }
        if (player.activeSelf)
        {
            menu.SetActive(false);
        }
        if (menu.activeSelf)
        {
            player.SetActive(false);
        }
        else {
            player.SetActive(true);
        }
    }


    // not useful yet


    /*
    public static GameManager Instance;

    // Start is called before the first frame update
    private void Awake(){
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
}

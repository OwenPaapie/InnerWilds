using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform HighlighFather; //Father of all the highlighted objects
    //[SerializeField] private GameObject Pannel; //Pannel to make scene darker during the Seeking mode
    [SerializeField] private GameObject lit;//light
    private Renderer rend; // renderer of the highlited objects
    [SerializeField] private List<GameObject> Highlight; // List of all the objects to be highlighted

    private void Start(){
        // gets all the children of the father and sorts them in an array-list
        foreach (Transform child in HighlighFather) {
            Highlight.Add(child.gameObject);
        }
            
    }

    // Update is called once per frame
    void Update(){
        // when in seeking mode
        if (Input.GetKey(KeyCode.Tab)){
            for (int i = 0; i < Highlight.Count; i++) {
                // change Shader
                rend = Highlight[i].GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Shader Graphs/OutlineShader");
                rend.material.SetFloat("_rimPower", -1f);
                // makes screen darker
                //Pannel.SetActive(true);
                lit.GetComponent<Light>().intensity = 0.2f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Tab)) {
            for (int i = 0; i < Highlight.Count; i++)
            {
                //resets shader
                rend = Highlight[i].GetComponent<Renderer>();
                rend.material.shader = Shader.Find("UniversalRendererPipeline/Lit");
                // removes darkening object
                //Pannel.SetActive(false);
                lit.GetComponent<Light>().intensity = 2f;
            }
        }
    }

}

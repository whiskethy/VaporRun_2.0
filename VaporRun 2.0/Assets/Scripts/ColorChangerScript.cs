using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerScript : MonoBehaviour
{
    public GameObject ship;
    Shader shader1;
    Shader shader2;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = ship.GetComponent<Renderer> ();
        shader1 = Shader.Find("Diffuse");
        shader2 = Shader.Find("Transparent/Diffuse");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            rend.material.shader = shader2;
        }
    }
}

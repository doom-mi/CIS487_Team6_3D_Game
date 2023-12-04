using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRadius : MonoBehaviour
{
    public int rad;
    bool displayRad = false;

    // Start is called before the first frame update
    void Start() {
        //Change scale of Detector Object to Radius Variable
        transform.localScale = new Vector3(rad, rad, rad);
    }


    // Update is called once per frame
    void Update()
    {
        //Check if LeftShift got pressed
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            //Toggle every time LeftShift is pressed
            if (displayRad == true){
                //Disable Mesh Renderer (Tower Radius)
                displayRad = false;
                transform.GetComponent<Renderer>().enabled = displayRad;
            } else if (displayRad == false){
                //Enable Mesh Renderer (Tower Radius)
                displayRad = true;
                transform.GetComponent<Renderer>().enabled = displayRad;
            }
        }

    }


}

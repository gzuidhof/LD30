using UnityEngine;
using System.Collections;

public class ButtonToEnable : MonoBehaviour {

    public KeyCode key = KeyCode.Space;
    public GameObject targetEnable;
    public GameObject targetDisable;


	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key))
        {
            if (targetEnable)
                targetEnable.SetActive(true);
            if (targetDisable)
                targetDisable.SetActive(false);
        }
            
	}
}

using UnityEngine;
using System.Collections;

public class ReloadButton : MonoBehaviour {

    public KeyCode key = KeyCode.R;

	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}

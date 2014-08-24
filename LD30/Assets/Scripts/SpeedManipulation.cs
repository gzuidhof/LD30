using UnityEngine;
using System.Collections;

public class SpeedManipulation : MonoBehaviour {

    public TextMesh textMesh;


	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Time.timeScale += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Time.timeScale -= 0.1f;
        }

        textMesh.text = "TIMESCALE " + ((int)(Time.timeScale * 100f));

	}
}

using UnityEngine;
using System.Collections;

public class SceneSwitchButton : MonoBehaviour {



    public string levelname;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
            if (hit.collider && hit.collider.GetComponent<SceneSwitchButton>())
                Application.LoadLevel(hit.collider.GetComponent<SceneSwitchButton>().levelname);
        }
	}
}

using UnityEngine;
using System.Collections;

public class MouseHover : MonoBehaviour {



    public bool mouseClaim;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
        if (hit.collider)
        {
            Orbit orbit = hit.collider.gameObject.GetComponent<Orbit>();
            if (orbit)
            {
                OrbitPreview.instance.setAroundBody(orbit.around);
                OrbitPreview.instance.setSpeed(orbit.speed);
                OrbitPreview.instance.setDistance(orbit.distance);
            }
        }
	}
}

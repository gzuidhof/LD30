using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {


    public float scaleSpeed = 0.1f;
    public float scaleMax = 3f;
    public float scaleMin = 1f;

    public bool direction;

	// Use this for initialization
	void Start () {
	    
	}
	
    void OnEnable()
    {
        transform.localScale = Vector3.one;
    }


	// Update is called once per frame
	void Update () {
        if (direction)
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        else
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;

        if (transform.localScale.x > scaleMax && direction)
            direction = false;

        else if (transform.localScale.x < scaleMin && !direction)
            direction = true;

	}
}

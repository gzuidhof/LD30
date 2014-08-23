using UnityEngine;
using System.Collections;

public class OrbitPreview : MonoBehaviour {

    public Orbit[] previewNodes;

    void Start ()
    {
        int length = previewNodes.Length;

        for (int i = 0; i < length; i++)
        {
            previewNodes[i].around = transform;
            previewNodes[i].position = ((float)i / (float)length) * 2f * Mathf.PI - Mathf.PI;
        }

        setSpeed(0.2f);
        setDistance(6f);


    }

	// Update is called once per frame
	void Update () {
	    
	}

    public void setSpeed(float speed)
    {
        foreach (Orbit n in previewNodes)
        {
            n.speed = speed;
        }
    }

    public void setDistance(float distance)
    {
        foreach (Orbit n in previewNodes)
        {
            n.distance = distance;
        }
    }

    public void setAroundBody(Transform body)
    {
        transform.parent = body;
    }



}

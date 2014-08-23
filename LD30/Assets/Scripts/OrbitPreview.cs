using UnityEngine;
using System.Collections;

/// <summary>
/// Dirty singleton class for orbit preview
/// </summary>
public class OrbitPreview : MonoBehaviour {

    public static OrbitPreview instance;
    public Orbit[] previewNodes;


    private float speed = 0.2f;
    private float distance = 0.2f;

    void Start ()
    {
        instance = this;
        int length = previewNodes.Length;

        for (int i = 0; i < length; i++)
        {
            previewNodes[i].around = transform;
            previewNodes[i].position = ((float)i / (float)length) * 2f * Mathf.PI - Mathf.PI;
        }

        setSpeed(speed);
        setDistance(2f);


    }

	// Update is called once per frame
	void Update () {
	    
	}

    public void setSpeed(float speed)
    {
        if (Mathf.Abs(this.speed - speed) < 0.005f) return;

        foreach (Orbit n in previewNodes)
        {
            n.speed = speed * 3f;
        }
    }


    public void setDistance(float distance)
    {
        if (Mathf.Abs(this.distance - distance) < 0.001f) return;
        foreach (Orbit n in previewNodes)
        {
            n.distance = distance;
        }

        foreach (Orbit o in previewNodes)
        {
            TrailRenderer tr = o.GetComponent<TrailRenderer>();
            tr.time = -1f;

        }
        StartCoroutine(startTrails());
       // this.Invoke("startTrails", 0.5f);

    }

    public void setAroundBody(Transform body)
    {
        if (transform.parent == body) return;
        transform.parent = body;
        transform.position = body.position;

        
        

    }

    public IEnumerator startTrails()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (Orbit o in previewNodes)
        {
            TrailRenderer tr = o.GetComponent<TrailRenderer>();
            tr.time = 1f;
        }
    }



}

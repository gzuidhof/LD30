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
        DistributeNodes();

        setSpeed(speed);
        setDistance(2f);


    }

    private void DistributeNodes()
    {
        int length = previewNodes.Length;

        for (int i = 0; i < length; i++)
        {
            previewNodes[i].around = transform;
            previewNodes[i].position = ((float)i / (float)length) * 2f * Mathf.PI - Mathf.PI;
        }
    }





	// Update is called once per frame
	void Update () {
	    
	}

    public void setSpeed(float speed)
    {
        if (Mathf.Abs(this.speed - speed) < 0.005f) return;

        foreach (Orbit n in previewNodes)
        {
            n.speed = speed >= 0f ? 0.30f : -0.30f;
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
        DistributeNodes();
        
        

    }

    public IEnumerator startTrails()
    {
        yield return new WaitForSeconds(0.02f);
        foreach (Orbit o in previewNodes)
        {
            TrailRenderer tr = o.GetComponent<TrailRenderer>();
            //tr.time = 1.5f;
            tr.time = 1.5f;
            //Debug.Log(tr.time);
        }
    }



}

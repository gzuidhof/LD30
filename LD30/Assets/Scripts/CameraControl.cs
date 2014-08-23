using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public float snappiness = 0.5f;
    public float zoomSnappiness = 0.5f;

    public float dragSpeed = 20f;
    public float scrollSpeed = 2f;

    public Plane solarPlane;
    private Vector3 lastRayIntersect;

	// Use this for initialization
	void Start () {
        solarPlane = new Plane(Vector3.zero, Vector3.up, Vector3.right);
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        Vector3 velocity = Vector3.zero;


        if (Input.GetKey(KeyCode.Mouse0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            if (solarPlane.Raycast(ray, out dist))
            {
                if (lastRayIntersect != Vector3.zero)
                {
                    if (Vector3.Distance(lastRayIntersect, ray.GetPoint(dist)) > 0.2f)
                        velocity = new Vector3 (lastRayIntersect.x - ray.GetPoint(dist).x, lastRayIntersect.y - ray.GetPoint(dist).y, 0f);
                }
                lastRayIntersect = ray.GetPoint(dist);
            }

        }
        else
        {
            lastRayIntersect = Vector3.zero;
        }
        float z = Input.GetAxis("Mouse ScrollWheel");

        rigidbody.velocity = new Vector3(
            Mathf.Lerp(rigidbody.velocity.x, velocity.x * dragSpeed, snappiness), 
            Mathf.Lerp(rigidbody.velocity.y, velocity.y * dragSpeed, snappiness),
            Mathf.Lerp(rigidbody.velocity.z, z * scrollSpeed, zoomSnappiness * Time.deltaTime));
	}
}

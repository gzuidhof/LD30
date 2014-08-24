﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public float snappiness = 0.5f;
    public float zoomSnappiness = 0.5f;

    public float dragSpeed = 20f;
    public float scrollSpeed = 2f;

    public Plane solarPlane;
    private Vector3 lastRayIntersect;

    private float lastZoom;
    public float zoomSustain = 100f;


    private MouseHover mouse;

	// Use this for initialization
	void Start () {
        solarPlane = new Plane(Vector3.zero, Vector3.up, Vector3.right);
        mouse = GetComponent<MouseHover>();
	}
	

    void LateUpdate()
    {
        camera.orthographicSize = Mathf.Abs(transform.position.z);
    }

	// Update is called once per frame
	void FixedUpdate () {


        Vector3 velocity = Vector3.zero;
        bool mouseAvailable = true;
        if (mouse)
            mouseAvailable = !mouse.mouseClaim;
        //Drag
        if ((Input.GetKey(KeyCode.Mouse0) && mouseAvailable) || Input.GetKey(KeyCode.Mouse2))
        {
            //Raycast into plane that makes up the solar platter
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            if (solarPlane.Raycast(ray, out dist))
            {
                if (lastRayIntersect != Vector3.zero)
                {
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
        z = Mathf.Clamp(z, -0.25f, 0.25f);
        z = Mathf.Lerp(lastZoom, z, Time.deltaTime * zoomSustain);


        rigidbody.velocity = new Vector3(
            Mathf.Lerp(rigidbody.velocity.x, velocity.x * dragSpeed, snappiness), 
            Mathf.Lerp(rigidbody.velocity.y, velocity.y * dragSpeed, snappiness),
            Mathf.Lerp(rigidbody.velocity.z, z * scrollSpeed, zoomSnappiness));

        if (transform.position.z > -1.6f && rigidbody.velocity.z > 0f)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0f);
        }
        if (transform.position.z > -1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        }



        lastZoom = z;
	}
}

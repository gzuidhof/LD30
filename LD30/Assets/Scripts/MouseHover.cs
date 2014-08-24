using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class MouseHover : MonoBehaviour {



    public bool mouseClaim;
    public Relay from;

    public LineRenderer line;

    public GameObject highlightRelay;
    public GameObject highlightTarget;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        bool previewInUse = false;
        if (BuySattelitePreview.instance.gameObject.activeSelf)
        {
            Orbit orbit = BuySattelitePreview.instance.GetComponent<Orbit>();
            OrbitPreview.instance.setAroundBody(orbit.around);
            OrbitPreview.instance.setSpeed(orbit.speed);
            OrbitPreview.instance.setDistance(orbit.distance);
            previewInUse = true;
        }



        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);
        Relay relay = null;
        if (hit.collider)
        {
            if (hit.collider.gameObject.tag != "Packet" && hit.collider.gameObject.tag != "Planet")
            {
                highlightRelay.SetActive(true);
                highlightRelay.transform.position = hit.collider.transform.position;

            }
            else if (hit.collider.gameObject.tag == "Packet")
            {
                highlightTarget.SetActive(true);
                Packet hoverPackage = hit.collider.transform.root.GetComponent<Packet>();

                highlightTarget.transform.position = hoverPackage.destination.transform.position;
                highlightTarget.renderer.material.color = hoverPackage.color;
            }
            else
            {
                highlightRelay.SetActive(false);
                highlightTarget.SetActive(false);
            }

            if (hit.collider.gameObject.tag == "Planet" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                BuySattelitePreview.instance.gameObject.SetActive(true);
                BuySattelitePreview.instance.around = hit.collider.GetComponent<Planet>();
            }


            relay = GetRelay(hit.collider.gameObject);

            Orbit orbit = hit.collider.gameObject.GetComponent<Orbit>();



            if (orbit && !from && !previewInUse)
            {
                OrbitPreview.instance.setAroundBody(orbit.around);
                OrbitPreview.instance.setSpeed(orbit.speed);
                OrbitPreview.instance.setDistance(orbit.distance);
            }



            if (Input.GetKeyDown(KeyCode.Mouse0) && relay || BuySattelitePreview.instance.gameObject.activeSelf)
            {
                mouseClaim = true;
                if (relay && !BuySattelitePreview.instance.gameObject.activeSelf)
                    from = relay;
            }

        }
        else
        {
            highlightRelay.SetActive(false);
            highlightTarget.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && BuySattelitePreview.instance.gameObject.activeSelf)
        {
            GameManager.instance.BuySattelite();
            BuySattelitePreview.instance.gameObject.SetActive(false);
        }


        if (Input.GetKeyUp(KeyCode.Mouse0) && hit.collider)
        {
            mouseClaim = false;
            if (relay && relay != from)
            {
                from.target = relay;
            }

            from = null;
        }

        if (from)
        {
            line.SetPosition(0, from.transform.position);
            if (relay)
                line.SetPosition(1, relay.transform.position);
            else
            {
                line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
        else
        {
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
        }

	}

    private Relay GetRelay(GameObject go)
    {
        Relay r = go.GetComponent<Relay>();
        if (r == null && go.transform.parent)
            r = go.transform.parent.GetComponent<Relay>();

        return r;

    }


}

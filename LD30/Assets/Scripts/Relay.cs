using UnityEngine;
using System.Collections;

public class Relay : MonoBehaviour {

    public Relay target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PacketArrive(Packet package)
    {
        if (package.destination == this)
            ;//Do something
        else if (target == null)
            package.DestroyPackage();
        else
        {
            package.target = target;
            package.audio.Play();
        }

    }


}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject sattelitePrefab;
    public GameObject successPrefab;

	// Use this for initialization
	void Start () {
        instance = this;

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Score(Packet p)
    {
        GameObject suc = (GameObject) GameObject.Instantiate(successPrefab, p.transform.position, Quaternion.identity);
        suc.GetComponent<ParticleSystem>().startColor = p.color;
        suc.audio.pitch = p.audio.pitch;
        Destroy(p.gameObject);
        Destroy(suc.gameObject, 10f);
    }


    public void BuySattelite()
    {
        BuySattelitePreview p = BuySattelitePreview.instance;
        if (!p.isValid) return;

        GameObject sat = (GameObject)GameObject.Instantiate(sattelitePrefab, p.transform.position, p.transform.rotation);
        sat.GetComponent<Orbit>().around = p.around.transform;
        SetRealisticSpeed(sat);

    }

    public static void SetRealisticSpeed(GameObject sat)
    {
        Vector3 extraP = sat.GetComponent<Orbit>().ExtraPolate(1f);
        float dist = Vector3.Distance(sat.transform.position, extraP);
        sat.GetComponent<Orbit>().speed = sat.GetComponent<Orbit>().speed * 30f / (dist * dist);
    }



    internal static void RegisterDestination(Relay relay)
    {
        relay.SetColor(ColorUtil.GenerateGoldenRatioColor());
    }
}

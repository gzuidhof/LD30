﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject sattelitePrefab;


	// Use this for initialization
	void Start () {
        instance = this;

        foreach (var dest in Relay.destinations)
        {
            Debug.Log("awroo");
            dest.SetColor(ColorUtil.GenerateGoldenRatioColor());
        }

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void BuySattelite()
    {
        BuySattelitePreview p = BuySattelitePreview.instance;
        if (!p.isValid) return;

        GameObject sat = (GameObject)GameObject.Instantiate(sattelitePrefab, p.transform.position, Quaternion.identity);
        sat.GetComponent<Orbit>().around = p.around.transform;
        SetRealisticSpeed(sat);

    }

    public static void SetRealisticSpeed(GameObject sat)
    {
        Vector3 extraP = sat.GetComponent<Orbit>().ExtraPolate(1f);
        float dist = Vector3.Distance(sat.transform.position, extraP);
        sat.GetComponent<Orbit>().speed = sat.GetComponent<Orbit>().speed * 30f / (dist * dist);
    }


}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

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
}

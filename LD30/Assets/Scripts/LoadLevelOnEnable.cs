using UnityEngine;
using System.Collections;

public class LoadLevelOnEnable : MonoBehaviour {

    public string levelname = "space";


	void OnEnable()
    {
        Application.LoadLevel(levelname);
    }
}

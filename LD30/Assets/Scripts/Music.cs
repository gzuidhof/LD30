using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    public float maxSilence = 10f;
    public float minSilence = 3f;

    public GameObject[] songs;

    private GameObject current;

	// Use this for initialization
	void Start () {
        Invoke("PlayNextSong", GetInterval());
	}
	

    private float GetInterval()
    {
        return Random.Range(minSilence, maxSilence);
    }


    void PlayNextSong()
    {
        GameObject nextSong;

        do
        {
            nextSong = songs[Random.Range(0, songs.Length - 1)];
        }
        while (nextSong == current && songs.Length > 1);

        if (current != null)
             current.SetActive(false);

        current = nextSong;
        current.SetActive(true);
        float songLength = current.GetComponent<AudioSource>().clip.length;
        Invoke("PlayNextSong", songLength + GetInterval());

    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoom_Duck : MonoBehaviour
{
    public GameObject[] Ducks = new GameObject[4];
    public AudioClip[] DuckSounds = new AudioClip[4];
    AudioSource duckSource;
    // Start is called before the first frame update
    void Start()
    {
        duckSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(Ducks[0].transform.position.x);
            duckSource.clip = DuckSounds[0];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(Ducks[1].transform.position.x);
            duckSource.clip = DuckSounds[1];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(Ducks[2].transform.position.x);
            duckSource.clip = DuckSounds[2];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(Ducks[3].transform.position.x);
            duckSource.clip = DuckSounds[3];
            duckSource.loop = false;
            duckSource.mute = false;
            duckSource.Play();
        }
    }
}

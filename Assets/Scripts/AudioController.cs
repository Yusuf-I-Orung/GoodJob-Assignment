using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip Pop;
    public AudioClip Slime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(1))
        {
            source.PlayOneShot(Pop);
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            source.loop = true;
            source.clip = Slime;
            source.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            source.loop = false;
            source.Stop();
            source.PlayOneShot(Pop);
        }
    }
}

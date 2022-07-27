using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    public GameObject controller;
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
       gotWaxed(transform.gameObject);
    }
    void gotWaxed(GameObject go)
    {
        SpawnHair spawnHair = transform.parent.GetComponent<SpawnHair>();
        WaxingController wc = controller.transform.GetComponent<WaxingController>();
        spawnHair.WaxedHairs.Add(transform.gameObject);
        wc.state = "waxing";
    }
}

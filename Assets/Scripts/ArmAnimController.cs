using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimController : MonoBehaviour
{
    Animator anim;
    MeshCollider MC;

    public string state;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        MC = transform.GetChild(0).GetChild(0).GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "clean")
        {
            MC.enabled = false;
            anim.SetBool("clean", true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("waxedT");
        }
    }
}

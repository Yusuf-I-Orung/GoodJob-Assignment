using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentProperly : MonoBehaviour
{
    public GameObject Parent1;
    public GameObject ToParent1;
    public GameObject Parent2;
    public GameObject ToParent2;
    // Start is called before the first frame update
    public void SetParent()
    {
        ToParent1.transform.parent = Parent1.transform;
        ToParent2.transform.parent = Parent2.transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaxingController : MonoBehaviour
{
    public string state = "idle";
    public List<Vector3> Anchors;
    public List<GameObject> Waxes;
    public GameObject ToSpawn;
    private StickController stickController;
    private void Start()
    {
        stickController = transform.GetComponent<StickController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && ! EventSystem.current.IsPointerOverGameObject())
        {
            GameObject wax = Instantiate(ToSpawn, stickController.passHit.point, Quaternion.FromToRotation(-transform.right, stickController.passHit.normal));
            Waxes.Add(wax);
            Debug.Log(stickController.passHit.point);
        }
        //For PC
        /*
        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject wax in Waxes)
            {
                Destroy(wax);
            }

        }
        if (Input.GetMouseButtonUp(1))
        {
            for (var i = Waxes.Count - 1; i > -1; i--)
            {
                if (Waxes[i] == null)
                    Waxes.RemoveAt(i);
            }
        }
        */
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject wax in Waxes)
            {
                Destroy(wax);
            }
            for (var i = Waxes.Count - 1; i > -1; i--)
            {
                if (Waxes[i] == null)
                    Waxes.RemoveAt(i);
            }
        }
    }
}

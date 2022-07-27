using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public float depth = 5f;

    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions

    public float Raycast_length = 16f;

    private Vector3 wantedPos;

    public float mouseSensitivity = 0.5f;

    public RaycastHit passHit;

    void Update()
    {
        var mousePos = Input.mousePosition;
        Vector3 vector3 = new Vector3(mousePos.x, mousePos.y, depth);
        if (!Input.GetMouseButton(0))
        {
            wantedPos = Camera.main.ScreenToWorldPoint(vector3);
            WaxingController wc = transform.GetComponent<WaxingController>();
            wc.state = "idle";
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Camera.main.ScreenPointToRay(Input.mousePosition);// new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Raycast_length, LayerMask.GetMask("Arm")))
        {
            passHit = hit;
            if (Input.GetMouseButton(0))
            {
                Vector3 mouseInput = new Vector3(Input.GetAxis("Mouse X") * mouseSensitivity, 0, Input.GetAxis("Mouse Y") * mouseSensitivity);
                Vector3 vector33 = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, hit.point.y, mousePos.y));
                wantedPos = hit.point + mouseInput + new Vector3(0, .01f, 0); //
            }


            Debug.DrawRay(ray.origin, -transform.up * hit.distance, Color.yellow);

        }
        else
        {
            wantedPos = Camera.main.ScreenToWorldPoint(vector3);
            Debug.DrawRay(ray.origin, ray.origin - transform.up * Raycast_length, Color.white);
        }
        Vector3 interpolatedPosition = Vector3.Lerp(transform.position, wantedPos, .5f);
        transform.position = interpolatedPosition;
    }
}

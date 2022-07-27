using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHair : MonoBehaviour
{
    public GameObject ToSpawn;

    public List<GameObject> Hairs;
    public List<GameObject> RaycastPoints;
    public List<GameObject> Pivots;
    public int hairStartLoopCount= 400;

    public List<GameObject> WaxedHairs;

    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < hairStartLoopCount; j++)
        {
                float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

                Vector3 interpolatedPosition = Vector3.Lerp(RaycastPoints[0].transform.position, RaycastPoints[1].transform.position, interpolationRatio);

                elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)

                GameObject point = RaycastPoints[0];
                Ray ray = new Ray(interpolatedPosition, -point.transform.up);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 16f))
                {
                    Debug.DrawRay(ray.origin, -point.transform.up * hit.distance, Color.yellow);
                    GameObject hair = Instantiate(ToSpawn, hit.point, ToSpawn.transform.rotation);
                    hair.transform.parent = gameObject.transform;
                    Hairs.Add(hair);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.origin - point.transform.up * 16, Color.white);
                }

            float angle = Random.Range(0, 2);

            RaycastPoints[0].transform.position += new Vector3(0, 0, .001f);//RaycastPoints[0].transform.RotateAround(Pivots[0].transform.position, RaycastPoints[0].transform.right, angle);
            RaycastPoints[1].transform.position += new Vector3(0, 0, .001f);//RaycastPoints[1].transform.RotateAround(Pivots[1].transform.position, RaycastPoints[1].transform.right, angle);
            //RaycastPoints[2].transform.position += new Vector3(0, 0, .001f);//RaycastPoints[2].transform.RotateAround(Pivots[2].transform.position, RaycastPoints[2].transform.right, angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        /*
        if (Input.GetMouseButtonDown(1))
            {
                foreach (GameObject hair in WaxedHairs)
                {
                    Destroy(hair);
                }

            }
        if (Input.GetMouseButtonUp(1))
        {
            for (var i = WaxedHairs.Count - 1; i > -1; i--)
            {
                if (WaxedHairs[i] == null)
                WaxedHairs.RemoveAt(i);
            }
            for (var i = Hairs.Count - 1; i > -1; i--)
            {
                if (Hairs[i] == null)
                    Hairs.RemoveAt(i);
            }
        }
        */
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject hair in WaxedHairs)
            {
                Destroy(hair);
            }
            for (var i = WaxedHairs.Count - 1; i > -1; i--)
            {
                if (WaxedHairs[i] == null)
                    WaxedHairs.RemoveAt(i);
            }
            for (var i = Hairs.Count - 1; i > -1; i--)
            {
                if (Hairs[i] == null)
                    Hairs.RemoveAt(i);
            }
        }
    }
       
}

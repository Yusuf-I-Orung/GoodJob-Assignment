using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateCam : MonoBehaviour
{
    public Camera cam;
    public Transform origin;
    public GameObject stick;
    public void rotate()
    {
        cam.transform.RotateAround(origin.position, origin.up, 180);
        stick.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
    }
    public void restart()
    {
        SceneManager.LoadScene("Wax");
    }
    public void Exit()
    {
            Application.Quit();
    }

}

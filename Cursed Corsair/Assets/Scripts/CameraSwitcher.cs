using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Camera[] cameras;
    int currentCameraIndex;

    void Start()
    {
        currentCameraIndex = 0;
        // Enable the first camera and disable the rest
        for (int i = 0; i < cameras.Length; i++)
        {
            //Shortest possible way to disable all camera's that aren't the current camera (Thanks to my AI assistant Aria)
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }
 
    public void SwitchCamera(int nextCamera)
    {
        cameras[currentCameraIndex].gameObject.SetActive(false);
        cameras[nextCamera].gameObject.SetActive(true);
        currentCameraIndex = nextCamera;
    }
}

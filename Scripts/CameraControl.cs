using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera cam;

    private int defaultWidth = 1920;
    private float defaultOrthographicScale = 5.0f;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        int actualWidth = Screen.width;

        if (actualWidth != defaultWidth) // If screen is not 1920x1080, do calculations to resize it
            CentreCamera(actualWidth);
    }

    public void CentreCamera(int width)
    {
        float widthScale = (float)defaultWidth / (float)width; // How much bigger or smaller is the width than expected

        float sizeNeeded = widthScale * defaultOrthographicScale; // Alter the orthographic size by the difference in scale

        cam.orthographicSize = sizeNeeded; // Update the size in the camera object
    }
}

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    void Awake()
    {
        //To adjust the camera size for responsive screen size
        float screenWidth = (float)Screen.width;
        float screenHeight = (float)Screen.height;
        float screenRatio = screenWidth / screenHeight;
        float camSize = 6.4f / screenRatio;
        Camera.main.orthographicSize = camSize;
    }
}
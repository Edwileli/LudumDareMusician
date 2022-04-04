using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 0.5f;

    private Camera currentCamera;

    void Awake()
    {
        currentCamera = FindObjectOfType<Camera>();
        if (!currentCamera)
        {
            Debug.Log("camera missing on " + gameObject.name);
        }
    }

    void Update()
    {
        if (currentCamera.transform.localEulerAngles.y < 200 && (Input.GetKey("right") || (Input.GetKey("d"))))
        {
            currentCamera.transform.Rotate(new Vector3(0f, cameraSpeed, 0f));
        }
        else if (currentCamera.transform.localEulerAngles.y > 150 && (Input.GetKey("left") || (Input.GetKey("a"))))
        {
            currentCamera.transform.Rotate(new Vector3(0f, -cameraSpeed, 0f));
        }
    }
}

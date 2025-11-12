using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera Camera;

    float xRotation = 0;

    float xSensitivity = 30;
    float ySensitivity = 30;

    public void ProcessLook(Vector2 input)
    {
        float mousex = input.x;
        float mousey = input.y;

        //calculate camera rotation 

        xRotation -= (mousey*Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mousex * Time.deltaTime) * xSensitivity);
    }
}

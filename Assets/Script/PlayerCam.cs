using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float _sensX;
    public float _sensY;

    public Transform _orientation;

    float _rotationX;
    float _rotationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensY;

        _rotationY += _mouseX;

        _rotationX -= _mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        _orientation.rotation = Quaternion.Euler(0, _rotationY, 0);
    }
}

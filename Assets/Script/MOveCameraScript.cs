using UnityEngine;

public class MOveCameraScript : MonoBehaviour
{

    public Transform _cameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _cameraPosition.position;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SpeedMaterScript : MonoBehaviour
{
    public GameObject _player;
    Rigidbody _rb;

    public GameObject _text;
    Text text;
    Vector3 _prevPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = _text.GetComponent<Text>();
        _rb = _player.GetComponent<Rigidbody>();
        _prevPosition = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mathf.Approximately(Time.deltaTime, 0))
        //    return;

        float vel = _rb.linearVelocity.magnitude;
        string vel_String = vel.ToString();

        text.text = "Speed : " + vel_String;
    }
}

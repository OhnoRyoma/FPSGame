using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Player�̏��
    GameObject _player;
    Vector3 _playerPosition;
    //Enemy�̃X�s�[�h
    [SerializeField] private float _speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPosition = _player.transform.position;

        transform.LookAt(_playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //Player�̕����w�i��
        _playerPosition = _player.transform.position;
        transform.LookAt(_playerPosition);
        _playerPosition = _player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition, _speed * Time.deltaTime);
    }
}

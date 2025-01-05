using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Playerの情報
    GameObject _player;
    Vector3 _playerPosition;
    //Enemyのスピード
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
        //Playerの方向ヘ進む
        _playerPosition = _player.transform.position;
        transform.LookAt(_playerPosition);
        _playerPosition = _player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _playerPosition, _speed * Time.deltaTime);
    }
}

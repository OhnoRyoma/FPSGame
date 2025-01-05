using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    enum Size
    {
        Small,
        Medium,
        Large,
    }

    //生成用prefab
    [Header("エネミー")]
    [SerializeField] private GameObject _enemyPrefab = null;

    //Player用
    GameObject _player;
    Vector3 _playerPosition;

    //Timer
    private float _countTime = 0f;
    [Header("生成までの時間")]
    [SerializeField] private float _span = 3f;

    //生成用乱数(前後、左右、位置)
    int _rndomFB;
    int _rndomLR;
    Vector3 _enemySpwnPosition = new Vector3(0, 0.5f, 0);

    //生成用乱数(距離)
    [Header("スポーンするプレイヤーからの最小距離")]
    [SerializeField, Range(3.0f, 20f)] float _positiveMin = 3.0f;
    //[SerializeField, Range(-3.0f, -20f)] float _negativeMin = -3.0f;
    [Header("スポーンするプレイヤーからの最大距離")]
    [SerializeField, Range(5.0f, 50f)] float _positiveMax = 5.0f;
    //[SerializeField, Range(-5.0f, -50f)] float _negativeMax = -5.0f;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _countTime += Time.deltaTime;

        if(_countTime > _span)
        {
            EnemyGenerate(_enemyPrefab);
            _countTime = 0f;
        }
    }

    public void EnemyGenerate(GameObject _enemyPrefab)
    {
        //playerの位置
        _playerPosition = _player.transform.position;

        //前後と左右の判定
        _rndomFB = Random.Range(0, 2);
        _rndomLR = Random.Range(0, 2);

        //プレイヤーからの距離を取るための処理
        float _randomPositiveX = Random.Range(_positiveMin, _positiveMax);
        float _randomPositiveZ = Random.Range(_positiveMin, _positiveMax);
        float _randomNegativeX = Random.Range(-_positiveMin, -_positiveMax);
        float _randomNegativeZ = Random.Range(-_positiveMin, -_positiveMax);
        //float _randomNegativeX = Random.Range(_negativeMin, _negativeMax);
        //float _randomNegativeZ = Random.Range(_negativeMin, _negativeMax);


        //右前、左前、右後、左後の位置決め
        switch(_rndomFB)
        {
            case 0:
                _enemySpwnPosition.z = _randomPositiveZ;
                break;

            case 1:
                _enemySpwnPosition.z = _randomNegativeZ;
                break;
        }

        switch (_rndomLR)
        {
            case 0:
                _enemySpwnPosition.x = _randomPositiveX;
                break;

            case 1:
                _enemySpwnPosition.x = _randomNegativeX;
                break;
        }

        //Playerの位置から算出した位置を指定
        _enemySpwnPosition = _enemySpwnPosition + _playerPosition;

        //Prefabの生成
        var _enemy = Instantiate(_enemyPrefab, _enemySpwnPosition, transform.rotation);
    }
}

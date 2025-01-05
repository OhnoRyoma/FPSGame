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

    //�����pprefab
    [Header("�G�l�~�[")]
    [SerializeField] private GameObject _enemyPrefab = null;

    //Player�p
    GameObject _player;
    Vector3 _playerPosition;

    //Timer
    private float _countTime = 0f;
    [Header("�����܂ł̎���")]
    [SerializeField] private float _span = 3f;

    //�����p����(�O��A���E�A�ʒu)
    int _rndomFB;
    int _rndomLR;
    Vector3 _enemySpwnPosition = new Vector3(0, 0.5f, 0);

    //�����p����(����)
    [Header("�X�|�[������v���C���[����̍ŏ�����")]
    [SerializeField, Range(3.0f, 20f)] float _positiveMin = 3.0f;
    //[SerializeField, Range(-3.0f, -20f)] float _negativeMin = -3.0f;
    [Header("�X�|�[������v���C���[����̍ő勗��")]
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
        //player�̈ʒu
        _playerPosition = _player.transform.position;

        //�O��ƍ��E�̔���
        _rndomFB = Random.Range(0, 2);
        _rndomLR = Random.Range(0, 2);

        //�v���C���[����̋�������邽�߂̏���
        float _randomPositiveX = Random.Range(_positiveMin, _positiveMax);
        float _randomPositiveZ = Random.Range(_positiveMin, _positiveMax);
        float _randomNegativeX = Random.Range(-_positiveMin, -_positiveMax);
        float _randomNegativeZ = Random.Range(-_positiveMin, -_positiveMax);
        //float _randomNegativeX = Random.Range(_negativeMin, _negativeMax);
        //float _randomNegativeZ = Random.Range(_negativeMin, _negativeMax);


        //�E�O�A���O�A�E��A����̈ʒu����
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

        //Player�̈ʒu����Z�o�����ʒu���w��
        _enemySpwnPosition = _enemySpwnPosition + _playerPosition;

        //Prefab�̐���
        var _enemy = Instantiate(_enemyPrefab, _enemySpwnPosition, transform.rotation);
    }
}

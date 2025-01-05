using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoinerScript : MonoBehaviour
{
    //Camera���擾
    private Camera _mainCamera;

    //Ray�Ŏ擾�����I�u�W�F�N�g�̊i�[�ꏊ
    RaycastHit _raycastHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;
        _raycastHit = new RaycastHit();
    }

    // Update is called once per frame
    void Update()
    {
        //���C���J������̃}�E�X�̈ʒu����Ray���Ǝ�
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _raycastHit))
        {
            Debug.Log(_raycastHit.collider.gameObject.tag);
            Debug.Log(_raycastHit.collider.gameObject.transform.position);
        }
    }
}

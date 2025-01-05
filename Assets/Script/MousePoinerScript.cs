using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoinerScript : MonoBehaviour
{
    //Cameraを取得
    private Camera _mainCamera;

    //Rayで取得したオブジェクトの格納場所
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
        //メインカメラ上のマウスの位置からRayを照射
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _raycastHit))
        {
            Debug.Log(_raycastHit.collider.gameObject.tag);
            Debug.Log(_raycastHit.collider.gameObject.transform.position);
        }
    }
}

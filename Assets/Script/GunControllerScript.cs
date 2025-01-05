using UnityEngine;

public class GunControllerScript : MonoBehaviour
{
    //弾発射までの時間
    [SerializeField] Transform _bulletSpans = null;
    
    //弾のダメージ数値
    [SerializeField, Min(0)] int _damage = 0;

    //
    [SerializeField] Transform _bullets = null; 
    //

    //



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

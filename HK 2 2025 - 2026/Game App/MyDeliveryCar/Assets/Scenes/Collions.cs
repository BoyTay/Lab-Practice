using System;
using UnityEngine;

public class Collions : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // private void OnCollisionEnter2D(Collision2D collision)//Được gọi khi 2 vật thể có Collider2D chạm nhau thật sự.

    // //Hai collider KHÔNG được bật Is Trigger.

    // //Ít nhất một trong hai phải có Rigidbody2D.
    // {
    //     Debug.Log("Đã va chạm");
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    //Được gọi khi một vật đi vào vùng trigger.

    //Collider của vùng đó phải bật Is Trigger.

    //Không tạo va chạm vật lý, chỉ phát hiện đi vào vùng.
    {
        if(collision.tag =="Package" && hasPackage==false)
        {
            Debug.Log("Đã nhặt được gói hàng");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject,destroyDelay);
        }
        if(collision.tag =="Location" && hasPackage==true)
        {
            Debug.Log("Đã đến đích");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}

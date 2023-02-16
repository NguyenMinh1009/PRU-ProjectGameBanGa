using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; //thay doi toc do vien đạn

    public float timeToDestroy;// thời gian để hủy viên đạn

    Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // 2 cách di chuyển 1 game object :
        // thay đổi position trong thanh phan transform
        // dùng phương thức AddForce của thành phần rigidbody2D

        //Vector2.up = (0,1)
        m_rb.velocity = Vector2.up * speed;// velocity là 1 vector
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed; //tốc độ máy bay

    public GameObject projectile;

    public Transform shootingPoint; //điểm bắn

    public float spawnTime; // khoảng thời gian sinh ra đạn sau khi viên đạn trước bắn ra

    float m_spawnTime; //Lưu trữ giá trị spawn time

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");

        m_spawnTime -= Time.deltaTime;

        if ((xDir < 0 && transform.position.x <= -8) || (xDir > 0 && transform.position.x >= 8)
            || (yDir < 0 && transform.position.y <=-4.3))
        {
            if (m_spawnTime <= 0)
            {
                Shoot();

                m_spawnTime = spawnTime;
            }
            return;
        }
        else
        {
            //Vector3.right là viết tắt của tọa độ(1, 0, 0)
            if (m_spawnTime <= 0)
            {
                Shoot();

                m_spawnTime = spawnTime;
            }
            transform.position += new Vector3(moveSpeed * xDir * Time.deltaTime, moveSpeed * yDir * Time.deltaTime, 0);
        }
    }

    public void Shoot()
    {
        if (projectile && shootingPoint)
        {
            Instantiate(projectile, shootingPoint.position, Quaternion.identity); // xuất hiện đạn ở điểm bắn
        }
    }

}

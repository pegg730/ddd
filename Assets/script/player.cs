using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class player : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] Transform tfFiredPos;
    [SerializeField] float m_fFireIntervalTime = 0.1f;
    [SerializeField] Shaking m_CameraShaking;
    public int m_iHp = 20;
    bool m_bPlay = true;
    Transform m_tfPlayer;
    float m_fSpeed = 10;
    float m_fCurrentFireInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_tfPlayer = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_bPlay)
            return;
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = m_tfPlayer.position;
            pos.x -= m_fSpeed * Time.deltaTime;
            m_tfPlayer.position = pos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = m_tfPlayer.position;
            pos.x += m_fSpeed * Time.deltaTime;
            m_tfPlayer.position = pos;
        }
        m_fCurrentFireInterval -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && m_fCurrentFireInterval<0)
        {
            GameObject bullet=GameObject.Instantiate(prefabBullet);
            bullet.transform.position = tfFiredPos.position;
            m_fCurrentFireInterval = m_fFireIntervalTime;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("monstor_bullet"))
        {
            bullet script = other.gameObject.GetComponent<bullet>();
            m_iHp -= script.m_iHurt;
            Destroy(other.gameObject);
            if(m_iHp<0)
            {
                //遊戲結束
            }
            m_CameraShaking.StartShaking();

        }
        if (other.CompareTag("AddHp"))
        {
            bullet script = other.gameObject.GetComponent<bullet>();
            m_iHp -= script.m_iHurt;
            Destroy(other.gameObject);
        }
    }
    public void StopGame()
    {
        m_bPlay = false;
    }

}

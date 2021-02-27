using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstor : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_iHp = 10;
    [SerializeField] private Group m_group;
    [SerializeField] private GameObject m_prefabBullet;
    public float m_fFireBulletTime;
    float m_fDowncountTime;
    private void Start()
    {
        m_fDowncountTime = m_fFireBulletTime;
    }
    private void Update()
    {
        m_fDowncountTime -= Time.deltaTime;
        if(m_fDowncountTime<0)
        {
            GameObject bullet = GameObject.Instantiate(m_prefabBullet);
            bullet.transform.position = gameObject.transform.position;
            m_fDowncountTime = m_fFireBulletTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet_tag"))
        {
            Destroy(other.gameObject);
            Debug.Log("Trigger.....");
            bullet bulletScript= other.gameObject.GetComponent<bullet>();
            m_iHp -= bulletScript.m_iHurt;
            if(m_iHp<=0)
            {
                Destroy(gameObject);
                m_group.DeadOneMonster();
            }
            Shaking shaking = gameObject.GetComponent<Shaking>();
            shaking.StartShaking();
        }
    }
}

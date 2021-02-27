using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstor_AddHp : MonoBehaviour
{
    [SerializeField] private GameObject m_prefabBullet;
    [SerializeField] private float m_fSpeed = 1;
    [SerializeField] private float m_fLive = 2;
  
    public int m_iHp = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += m_fSpeed * Time.deltaTime;
        gameObject.transform.position = pos;
        m_fLive -= Time.deltaTime;
        if (m_fLive < 0)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet_tag"))
        {
            Destroy(other.gameObject);
            Debug.Log("Trigger.....");
            bullet bulletScript = other.gameObject.GetComponent<bullet>();
            m_iHp -= bulletScript.m_iHurt;
            if (m_iHp <= 0)
            {
                Destroy(gameObject);

                GameObject bullet = GameObject.Instantiate(m_prefabBullet);
                bullet.transform.position = gameObject.transform.position;

            }
            Shaking shaking = gameObject.GetComponent<Shaking>();
            shaking.StartShaking();
        }
    }
}

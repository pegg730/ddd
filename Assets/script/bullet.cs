using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float m_fSpeed = 1;
    [SerializeField] private float m_fLive = 2;
    public int m_iHurt = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += m_fSpeed * Time.deltaTime;
        gameObject.transform.position = pos;
        m_fLive -= Time.deltaTime;
        if(m_fLive<0)
        {
            Destroy(gameObject);
        }
    }
}

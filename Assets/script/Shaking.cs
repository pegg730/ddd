using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    [SerializeField] float m_fShakedSpeed = 1;
    [SerializeField] float m_fShakeTime = 0.1f;

    bool m_bShake = false;

    float m_fCurrentShakeTime = 0;

    Vector3 m_OriginedPosition;
    void Start()
    {
        m_OriginedPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bShake)
        {
            Vector3 pos = gameObject.transform.position;
            m_fCurrentShakeTime += Time.deltaTime;
            if (m_fCurrentShakeTime < 0.25 * m_fShakeTime)
            {
                pos.x += m_fShakedSpeed * Time.deltaTime;
                gameObject.transform.position = pos;
            }
            else if (m_fCurrentShakeTime < 0.75 * m_fShakeTime)
            {
                pos.x -= m_fShakedSpeed * Time.deltaTime;
                gameObject.transform.position = pos;
            }
            else if (m_fCurrentShakeTime < 1.0 * m_fShakeTime)
            {
                pos.x += m_fShakedSpeed * Time.deltaTime;
                gameObject.transform.position = pos;
            }
            else
            {
                m_bShake = false;
                gameObject.transform.position = m_OriginedPosition;
            }
        }

    }
    public void StartShaking()
    {
        m_bShake = true;
        m_fCurrentShakeTime = 0;
        m_OriginedPosition = gameObject.transform.position;
        //gameObject.transform.position = m_OriginedPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField] float m_fShakedSpeed = 1;
    [SerializeField] float m_fShakeTime = 0.1f;
    [SerializeField] float m_fSpeed = 0.5f;
    [SerializeField] float m_fLive = 1;
    [SerializeField] GM m_GM;
    public int m_Num = 27;
    bool m_bShake = true;
    bool m_bPlay = true;
    float m_fCurrentShakeTime = 0;
    Vector3 m_OriginedPosition;
    int Times=0;
    // Start is called before the first frame update
    void Start()
    {
        m_OriginedPosition = gameObject.transform.position;
        Times = 0;
        m_bPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_bPlay)
            return;
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
                Times++;
                if(Times>=2)
                {
                    m_bShake = false;
                    gameObject.transform.position = m_OriginedPosition;
                    m_fCurrentShakeTime = 0;
                    Times = 0;
                }
                else
                {
                    m_fCurrentShakeTime = 0;
                }

            }
        }
        else
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += m_fSpeed * Time.deltaTime;
            gameObject.transform.position = pos;
            m_fLive -= Time.deltaTime;
            if (m_fLive < 0)
            {
                m_fLive = 1;
                m_OriginedPosition = pos;
                m_bShake = true;
            }
        }
    }
    public void StopGame()
    {
        m_bPlay = false;
    }
    
    public void DeadOneMonster()
    {
        m_Num--;
        if(m_Num<0)
        {
            m_GM.GameOver();
        }
    }
}

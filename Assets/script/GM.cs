using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField] player m_player;
    [SerializeField] Group m_Group;
    [SerializeField] DeadLine m_DeadLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameOver()
    {
        m_player.StopGame();
        m_Group.StopGame();
    }



}

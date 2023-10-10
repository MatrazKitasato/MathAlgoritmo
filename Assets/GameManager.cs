using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public SimpleList<int> score = new SimpleList<int>();

    void Start()
    {
        for(int i = 0; i < 4; i++)//1+n(1+1+2)
        {
            score.InsertNodeAtStart(0);//1
        }
        //Tiempo asintotico = 1+4n    O(n)
    }
}

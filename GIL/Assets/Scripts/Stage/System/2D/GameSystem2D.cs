using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem2D : MonoBehaviour
{
    StartDirector2D startDir;
    ClearDirector2D clearDir;
    DeathDirector2D deathDir;

    private void Start()
    {
        // コンポーネントの取得
        startDir = this.GetComponent<StartDirector2D>();
        clearDir = this.GetComponent<ClearDirector2D>();
        deathDir = this.GetComponent<DeathDirector2D>();
    }

    public void Clear()
    {
        clearDir.Clear();
    }

    public void Death()
    {
        deathDir.Death();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    StartDirector startDir;
    ClearDirector clearDir;
    DeathDirector deathDir;

    private void Start()
    {
        // コンポーネントの取得
        startDir = this.GetComponent<StartDirector>();
        clearDir = this.GetComponent<ClearDirector>();
        deathDir = this.GetComponent<DeathDirector>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundary : MonoBehaviour {

    public bool haveEnemies = false;
    public bool hasDoor = false;
    public GameObject enemyPool;
    public GameObject door;
    public Player player;

    private void Update()
    {
        if (hasDoor)
        {
            if(player.enemyKilled == 4)
            {
                Destroy(door);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject PoolManager;
    public GameObject Generator;
    // Start is called before the first frame update
    private void Awake()
    {
        Player.SetActive(true);
        PoolManager.SetActive(true);
        Generator.SetActive(true);
    }
}

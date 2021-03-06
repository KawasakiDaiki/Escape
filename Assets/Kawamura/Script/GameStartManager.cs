﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject FloorManager;
    public GameObject BackGround;
    // Start is called before the first frame update
    private void Awake()
    {
        Player.SetActive(true);
        BackGround.SetActive(true);
        FloorManager.SetActive(true);
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameState.InGame)
        {
            Player.SetActive(false);
            BackGround.SetActive(false);
            FloorManager.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
            BackGround.SetActive(true);
            FloorManager.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject FloorManager;
    public GameObject BackGround;
    public GameObject GameCavas;
    // Start is called before the first frame update
    private void Awake()
    {
        Player.SetActive(true);
        BackGround.SetActive(true);
        FloorManager.SetActive(true);
        GameCavas.SetActive(true);
    }
}

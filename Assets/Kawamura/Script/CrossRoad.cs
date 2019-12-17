using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRoad : MonoBehaviour
{ 
    private int _Line;//プレイヤーが今どこにいるか
    private float _Rote_y;
    

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMove1>();
        if(player)
        {
            
            switch(player._MoveCount_x)
            {
                case 1:
                    _Rote_y += 90;
                    other.gameObject.transform.Rotate(0,_Rote_y,0);
                    break;

                case -1:
                    _Rote_y -= 90;
                    other.gameObject.transform.Rotate(0, _Rote_y, 0);
                    break;
            }
        }
    }
}

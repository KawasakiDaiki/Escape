using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public float speed { get; set; }
    public int HP { get; set; }
    int maxHp = 300;

    [SerializeField] bool RandomDamage=false;

    public void SetHp(int hp=10)
    {
        HP = hp;
    }
    public void Damage(int damage)
    {
        HP -= damage;
    }
}

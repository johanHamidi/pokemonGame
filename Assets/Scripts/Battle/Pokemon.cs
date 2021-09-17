using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public PokemonBase Base{get; set;}
    public int Level{get; set;}
    public int HP{get; set;}

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;
    }

    public int Attack{
        get{return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5;}
    }

    public int Defense{
        get{return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5;}
    }

    public int SpAttack{
        get{return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5;}
    }

    public int SpDefense{
        get{return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5;}
    }

    public int Speed{
        get{return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5;}
    }

    public int MaxHp{
        get{return Mathf.FloorToInt((Base.MaxHp * Level) / 100f) + 10;}
    }
}

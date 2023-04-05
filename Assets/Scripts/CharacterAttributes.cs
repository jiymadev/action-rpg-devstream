using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    [SerializeField] int _str, _dex, _con, _int, _wis, _cha;
    
    public int Str => _str;
    public int Dex => _dex;
    public int Con => _con;
    public int Int => _int;
    public int Wis => _wis;
    public int Cha => _cha;

    /*
    public int Str 
    {
        get
        {
            return _str;
        }
    }
    */
}

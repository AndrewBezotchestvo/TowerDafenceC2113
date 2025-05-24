using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float _money;

    public float GetMoney()
    {
        return _money;
    }

    public void TakeMoney(float money)
    {
        _money += money;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour
{
    public int maxAmmunition;
    public int magazineCurrent;
    public int magazineSize;
    public Text ammo;
    public Text magazine;

    void Start()
    {
        magazine.text = magazineCurrent.ToString();
        ammo.text = maxAmmunition.ToString();
    }

    public bool Shooting()
    {
        if (magazineCurrent > 0)
        {
            magazineCurrent--;
            magazine.text = magazineCurrent.ToString();
            return true;
        }
        return false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        if(magazineSize-magazineCurrent <= maxAmmunition)
        {
            maxAmmunition -= magazineSize - magazineCurrent;
            magazineCurrent = magazineSize;
        }
        else
        {
            magazineCurrent += maxAmmunition;
            maxAmmunition = 0;
        }
        magazine.text = magazineCurrent.ToString();
        ammo.text = maxAmmunition.ToString();
    }
}

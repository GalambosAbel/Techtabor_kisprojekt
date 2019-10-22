using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour
{
    public int maxAmmunition;
    public int magazineCurrent;
    public Text ammoText;
    public Text magazineText;

    void Start()
    {
        magazineText.text = magazineCurrent.ToString();
        ammoText.text = maxAmmunition.ToString();
    }

	void Update()
	{
		if (magazineCurrent > maxAmmunition) magazineCurrent = maxAmmunition;
		magazineText.text = magazineCurrent.ToString();
	}

	public bool CanShoot()
    {
        if (magazineCurrent > 0)
        {
            magazineCurrent--;
            return true;
        }
        return false;
    }
}

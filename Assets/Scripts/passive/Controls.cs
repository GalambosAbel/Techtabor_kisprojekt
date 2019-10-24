using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text jump, left, right, shoot,leaveShop;
    public GameObject currentKey;

    void Start()
    {
        keys.Add("Jump", (KeyCode)PlayerPrefs.GetInt("Jump",32));
        keys.Add("Left", (KeyCode)PlayerPrefs.GetInt("Left",97));
        keys.Add("Right", (KeyCode)PlayerPrefs.GetInt("Right",100));
        keys.Add("Shoot", (KeyCode)PlayerPrefs.GetInt("Shoot",323));
        keys.Add("LeaveShop", (KeyCode)PlayerPrefs.GetInt("LeaveShop",108));
        jump.text = keys["Jump"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        shoot.text = keys["Shoot"].ToString();
        leaveShop.text = keys["LeaveShop"].ToString();
    }

    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                PlayerPrefs.SetInt(currentKey.name, (int)e.keyCode);
                currentKey.GetComponentInChildren<Text>().text = keys[currentKey.name].ToString();
                currentKey = null;
            }
            if (e.isMouse)
            {
                keys[currentKey.name] = (KeyCode)(e.button + 323);
                PlayerPrefs.SetInt(currentKey.name, e.button + 323);
                currentKey.GetComponentInChildren<Text>().text = keys[currentKey.name].ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}

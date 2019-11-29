using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text jump, left, right, shoot, leaveShop, jump2, left2, right2, shoot2, crosshairUp, crosshairDown, crosshairLeft, crosshairRight;
    public GameObject currentKey;

    void Start()
    {
        keys.Add("Jump", (KeyCode)PlayerPrefs.GetInt("Jump",273));
        keys.Add("Left", (KeyCode)PlayerPrefs.GetInt("Left",276));
        keys.Add("Right", (KeyCode)PlayerPrefs.GetInt("Right",275));
        keys.Add("Shoot", (KeyCode)PlayerPrefs.GetInt("Shoot",323));
        keys.Add("LeaveShop", (KeyCode)PlayerPrefs.GetInt("LeaveShop", 108));
        keys.Add("Jump2", (KeyCode)PlayerPrefs.GetInt("Jump2", 119));
        keys.Add("Left2", (KeyCode)PlayerPrefs.GetInt("Left2", 97));
        keys.Add("Right2", (KeyCode)PlayerPrefs.GetInt("Right2", 100));
        keys.Add("Shoot2", (KeyCode)PlayerPrefs.GetInt("Shoot2", 32));
        keys.Add("CrosshairUp", (KeyCode)PlayerPrefs.GetInt("CrosshairUp", 117));
        keys.Add("CrosshairDown", (KeyCode)PlayerPrefs.GetInt("CrosshairDown", 106));
        keys.Add("CrosshairRight", (KeyCode)PlayerPrefs.GetInt("CrosshairRight", 107));
        keys.Add("CrosshairLeft", (KeyCode)PlayerPrefs.GetInt("CrosshairLeft", 104));
        jump.text = keys["Jump"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        shoot.text = keys["Shoot"].ToString();
        leaveShop.text = keys["LeaveShop"].ToString();
        jump2.text = keys["Jump2"].ToString();
        left2.text = keys["Left2"].ToString();
        right2.text = keys["Right2"].ToString();
        shoot2.text = keys["Shoot2"].ToString();
        crosshairUp.text = keys["CrosshairUp"].ToString();
        crosshairDown.text = keys["CrosshairDown"].ToString();
        crosshairLeft.text = keys["CrosshairLeft"].ToString();
        crosshairRight.text = keys["CrosshairRight"].ToString();
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

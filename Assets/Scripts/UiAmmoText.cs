using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAmmoText : MonoBehaviour
{

    private Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = gameObject.GetComponent<Text>();
        EventManager.instance.OnPlayerFired += PlayerFired;
    }

    private void OnDisable()
    {
        EventManager.instance.OnPlayerFired -= PlayerFired;
    }

    void PlayerFired()
    {
        ammoText.text = "Ammo: 0";
    }

}

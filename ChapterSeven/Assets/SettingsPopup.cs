using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void open() {
        gameObject.SetActive(true);
    }

    public void close() {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name) {

    }

    public void OnSpeedValue(float speed) {

    }
}

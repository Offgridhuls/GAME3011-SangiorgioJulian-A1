using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text materialCounterText;
    public Text scansText;
    public Text extractsText;
    public Text modeText;
    public Button ToggleButton;

    void Update()
    {
        materialCounterText.text = "Material Count: " + GameManager.instance.totalMaterial.ToString();
        scansText.text = "Scans Left: " + GameManager.instance.scanCounter.ToString();
        extractsText.text = "Extracts Left: " + GameManager.instance.extractCounter.ToString();
        if (GameManager.instance._state == GameManager.State.Scan)
        {
            modeText.text = "Scan Mode";
        }
        else if (GameManager.instance._state == GameManager.State.Extract)
        {
            modeText.text = "Extract Mode";
        }
    }

    // Update is called once per frame
    public void OnToggleButtonPressed()
    {
        if (GameManager.instance._state == GameManager.State.Scan)
        {
            GameManager.instance._state = GameManager.State.Extract;
        }
        else if (GameManager.instance._state == GameManager.State.Extract)
        {
            GameManager.instance._state = GameManager.State.Scan;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int extractCounter;
    public int scanCounter;
    public int totalMaterial;
    public enum State
    {
        Extract = 0,
        Scan = 1,
    }

    public State _state;
    // Start is called before the first frame update

    void Start()
    {
        scanCounter = 6;
        extractCounter = 3;
        instance = this;
        _state = State.Scan;
    }

}

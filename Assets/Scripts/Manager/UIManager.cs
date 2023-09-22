using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<UIManager>();
            }
            return instance;
        }
    }

    public TMP_Text Banlance;
    public TMP_Text Cash;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetBanlance(string number)
    {
        Banlance.text = number;
    }
    public void SetCash(string number)
    {
        Cash.text = number;
    }
}

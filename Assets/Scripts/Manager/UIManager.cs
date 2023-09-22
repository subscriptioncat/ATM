using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public TMP_Text Balance;
    public TMP_Text Cash;

    public void DisPlay(string balance, string cash)
    {
        if (Balance == null)
        {
            Cash = GameObject.FindGameObjectWithTag("CashValue").GetComponent<TMP_Text>();
            Balance = GameObject.FindGameObjectWithTag("BalanceValue").GetComponent<TMP_Text>();
        }
        Balance.text = balance;
        Cash.text = cash;
    }
}

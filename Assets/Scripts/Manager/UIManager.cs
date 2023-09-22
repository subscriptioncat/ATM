using System;
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

    [SerializeField] private TMP_Text Balance;
    [SerializeField] private TMP_Text Cash;
    [SerializeField] private TMP_InputField inputField_Deposit;
    [SerializeField] private TMP_InputField inputField_Withdraw;
    [SerializeField] private GameObject InsufficientBalance_Popup;

    public event Action<int> OnDeposit;
    public event Action<int> OnWithdraw;
    public event Action<string, string> OnDisPlay;

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
    private void Start()
    {
        OnDisPlay += DisPlay;
    }

    public void CallDeposit(int number)
    {
        OnDeposit?.Invoke(number);
    }
    public void CallWithdraw(int number)
    {
        OnWithdraw?.Invoke(number);
    }

    public void CallDirectInputDeposit()
    {
        OnDeposit?.Invoke(int.Parse(inputField_Deposit.text));
    }
    public void CallDirectInputWithdraw()
    {
        OnWithdraw?.Invoke(int.Parse(inputField_Withdraw.text));
    }
    
    public void CallDisPlay(string balance, string cash)
    {
        OnDisPlay?.Invoke(balance, cash);
    }

    public void DisPlay(string balance, string cash)
    {  
        Balance.text = balance;
        Cash.text = cash;
    }

    public void PopupSetActive()
    {
        InsufficientBalance_Popup.SetActive(true);
    }
}

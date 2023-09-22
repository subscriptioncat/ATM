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
    public event Action<int, int> OnDisPlay;

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
    
    public void CallDisPlay(int balance, int cash)
    {
        OnDisPlay?.Invoke(balance, cash);
    }

    public void DisPlay(int balance, int cash)
    {
        Balance.text = string.Format("{0:#,###}", balance);
        Cash.text = string.Format("{0:#,###}", cash);
    }

    public void PopupSetActive()
    {
        InsufficientBalance_Popup.SetActive(true);
    }
}

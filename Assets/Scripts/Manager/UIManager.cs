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
    [SerializeField] private TMP_InputField inputField_ID;
    [SerializeField] private TMP_InputField inputField_PW;
    [SerializeField] private GameObject InsufficientBalance_Popup;
    [SerializeField] private GameObject SelectButton;
    [SerializeField] private GameObject AccountInformation;
    [SerializeField] private GameObject Login_PopUp;
    [SerializeField] private GameObject LoginError_PopUp;

    public event Action<int> OnDeposit;
    public event Action<int> OnWithdraw;
    public event Action<int, int> OnDisPlay;
    public event Action<string, string> OnLogin;

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

    public void CallLogin()
    {
        OnLogin?.Invoke(inputField_ID.text, inputField_PW.text);
    }

    public void DisPlay(int balance, int cash)
    {
        Balance.text = string.Format("{0:#,0.#}", balance);
        Cash.text = string.Format("{0:#,0.#}", cash);
    }

    public void PopupSetActive()
    {
        InsufficientBalance_Popup.SetActive(true);
    }

    public void SucceedLogin()
    {
        Login_PopUp.SetActive(false);
        SelectButton.SetActive(true);
        AccountInformation.SetActive(true);
    }

    public void FailLogin()
    {
        LoginError_PopUp.SetActive(true);
    }
}

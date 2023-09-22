using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMManager : MonoBehaviour
{
    private static ATMManager instance;
    public static ATMManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AccountForm nowAccount;

    void Start()
    {
        nowAccount = DataBase.Instance.Login("admin", "0000");
        UIManager.Instance.OnDeposit += Deposit;
        UIManager.Instance.OnWithdraw += Withdraw;
    }
    public void Deposit(int number)
    {
        if (nowAccount.Deposit(number))
        {
            UIManager.Instance.CallDisPlay(nowAccount.AccountAmount.ToString(), nowAccount.Cash.ToString());
        }
        else
        {
            UIManager.Instance.PopupSetActive();
        }
    }

    public void Withdraw(int number)
    {
        if (nowAccount.Withdraw(number))
        {
            UIManager.Instance.CallDisPlay(nowAccount.AccountAmount.ToString(), nowAccount.Cash.ToString());
        }
        else
        {
            UIManager.Instance.PopupSetActive();
        }
    }

}

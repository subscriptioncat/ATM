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
        DisPlayReset();
    }
    public void Deposit(int number)
    {
        if (nowAccount.Deposit(number))
        {
            UIManager.Instance.DisPlay(nowAccount.AccountAmount.ToString(), nowAccount.Cash.ToString());
        }
        else
        {
            //ÀÜ¾× ºÎÁ· Ã¢ ¶ç¿ì±â
        }

    }

    public void Withdraw(int number)
    {
        if (nowAccount.Withdraw(number))
        {
            UIManager.Instance.DisPlay(nowAccount.AccountAmount.ToString(), nowAccount.Cash.ToString());
        }
        else
        {
            //ÀÜ¾× ºÎÁ· Ã¢ ¶ç¿ì±â
        }

    }
    public void DisPlayReset()
    {
        UIManager.Instance.DisPlay(nowAccount.AccountAmount.ToString(), nowAccount.Cash.ToString());
    }

}

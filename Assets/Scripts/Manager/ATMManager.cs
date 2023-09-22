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
                GameObject go = new GameObject();
                instance = go.AddComponent<ATMManager>();
            }
            return instance;
        }
    }
    public AccountForm nowAccount;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        nowAccount = DataBase.Instance.Login("admin", "0000");
    }
    public void Deposit(int number)
    {
        if (nowAccount.Deposit(number))
        {
            UIManager.Instance.SetBanlance(nowAccount.AccountAmount.ToString());
            UIManager.Instance.SetCash(nowAccount.Cash.ToString());
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
            UIManager.Instance.SetBanlance(nowAccount.AccountAmount.ToString());
            UIManager.Instance.SetCash(nowAccount.Cash.ToString());
        }
        else
        {
            //ÀÜ¾× ºÎÁ· Ã¢ ¶ç¿ì±â
        }

    }

}

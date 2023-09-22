using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private static DataBase instance;
    public static DataBase Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<DataBase>();
            }
            return instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private List<AccountForm> _accounts;
    private void Awake()
    {
        _accounts = new List<AccountForm>();
        _accounts.Add(new AccountForm());
    }
    public AccountForm Login(string id, string pw)
    {
        foreach(AccountForm account in _accounts)
        {
            if(account.ID == id && account.PW == pw)
                return account;
        }
        return null;
    }

    public void CreateAccount(string id, string pw, string name, int accountAmount, int cash)
    {
        bool isAccountID = false;
        foreach (AccountForm account in _accounts)
        {
            if (account.ID == id)
            {
                isAccountID = true;
                break;
            }
        }
        if (!isAccountID)
        {
            _accounts.Add(new AccountForm(id, pw, name, accountAmount, cash));
        }
    }
}


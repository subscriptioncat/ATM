using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AccountForm
{
    private string _id;
    public string ID { get { return _id; } }
    private string _pw;
    public string PW { get { return _pw; } }
    private string _name;
    public string Name { get { return _name; } }
    private int _accountAmount;
    public int AccountAmount { get { return _accountAmount; } }
    private int _cash;
    public int Cash { get {  return _cash; } }
    
    public AccountForm()
    {
        _id = "admin";
        _pw = "0000";
        _name = "±èµµÇö";
        _accountAmount = 50000;
        _cash = 100000;
    }
    public AccountForm(string id, string pw, string name, int accountAmount, int cash)
    {
        _id = id;
        _pw = pw;
        _name = name;
        _accountAmount = accountAmount;
        _cash = cash;
    }

    public bool Deposit(int cash)
    {
        if(_cash >= cash)
        {
            _cash -= cash;
            _accountAmount += cash;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Withdraw(int accountAmount)
    {
        if (_accountAmount >= accountAmount)
        {
            _accountAmount -= accountAmount;
            _cash += accountAmount;
            return true;
        }
        else
        {
            return false;
        }
    }
}

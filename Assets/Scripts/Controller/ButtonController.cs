using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TMP_InputField inputField_Deposit;
    public TMP_InputField inputField_Withdraw;
    public void CallDepositScene()
    {
        SceneManager.LoadScene("DepositScene");
        //UIManager.Instance.Banlance = GameObject.Find("Canvas/Balance/BalanceValue").GetComponent<TMP_Text>();
        //UIManager.Instance.Cash = GameObject.Find("Canvas/Cash/CashValue").GetComponent<TMP_Text>();
        //var gameobject = SceneManager.GetActiveScene().GetRootGameObjects();
        //gameobject[1].GetComponentInChildren();

        //
        //UIManager.Instance.Cash
    }
    public void CallWithdrawScene()
    {
        SceneManager.LoadScene("WithdrawScene");
        //UIManager.Instance.Banlance = GameObject.Find("Canvas/Balance/BalanceValue").GetComponent<TMP_Text>();
        //UIManager.Instance.Cash = GameObject.Find("Canvas/Cash/CashValue").GetComponent<TMP_Text>();
    }
    public void CallMainScene()
    {
        SceneManager.LoadScene("MainScene");
        //UIManager.Instance.Banlance = GameObject.Find("Canvas/Balance/BalanceValue").GetComponent<TMP_Text>();
        //UIManager.Instance.Cash = GameObject.Find("Canvas/Cash/CashValue").GetComponent<TMP_Text>();
    }
    public void CallDeposit(int number)
    {
        ATMManager.Instance.Deposit(number);
    }
    public void CallWithdraw(int number)
    {
        ATMManager.Instance.Withdraw(number);
    }

    public void DirectInputDeposit()
    {
        ATMManager.Instance.Deposit(int.Parse(inputField_Deposit.text));
    }
    public void DirectInputWithdraw()
    {
        ATMManager.Instance.Withdraw(int.Parse(inputField_Deposit.text));
    }
}

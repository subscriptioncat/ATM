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
        ATMManager.Instance.DisPlayReset();
    }
    public void CallWithdrawScene()
    {
        SceneManager.LoadScene("WithdrawScene");
        ATMManager.Instance.DisPlayReset();
    }
    public void CallMainScene()
    {
        SceneManager.LoadScene("MainScene");
        ATMManager.Instance.DisPlayReset();
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

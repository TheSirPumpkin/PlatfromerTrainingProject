using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLSendTransactionExample : MonoBehaviour
{
    async public void OnSendTransaction()
    {
        // account to send to
        string to = PlayerPrefs.GetString("Account");//"0x428066dd8A212104Bc9240dCe3cdeA3D3A0f7979";
        // amount in wei to send
        string value = "123000";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendTransaction(to, value, gasLimit, gasPrice);
            Debug.Log(response);
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
}

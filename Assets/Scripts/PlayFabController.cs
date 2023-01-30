using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
        {
            //TitleId = "sample001",
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        },
        result =>
        {
            Debug.Log("おめでとうございます！ログイン成功です！");
            this.SetUserData();
        },
        error =>
        {
            Debug.Log(error + "ログインに失敗(ﾉД`)");
        }
        );
    }

    private void SetUserData()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>(){
                            {"Name", "joker"},
                            {"Exp", "1000"}
            }
        }, result =>
        {
            Debug.Log("プレイヤーデータの登録に成功");
        }, error =>
        {
            Debug.Log("Errorが発生しました");
        });
    }
}
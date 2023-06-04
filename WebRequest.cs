using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class WebRequest : MonoBehaviour
{
    string result,question;
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

        }
        
    }

    IEnumerator Request()
    {
        string url = "https://eolink.o.apispace.com/chatgpt/create";
        string token = "5bme3fjle4q47l33j1xid795o9anrta9";
        string requestBody = "{\"text\":\""+question+"\"}";

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.SetRequestHeader("X-APISpace-Token", token);
        request.SetRequestHeader("Authorization-Type", "apikey");
        request.SetRequestHeader("Content-Type", "application/json");

        byte[] requestBodyBytes = System.Text.Encoding.UTF8.GetBytes(requestBody);
        request.uploadHandler = new UploadHandlerRaw(requestBodyBytes);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            result = request.downloadHandler.text;
            string[] res = result.Split('\"');
            GameObject.Find("ResponseField").GetComponent<TMP_Text>().text = res[3];
        }
    }
    public void Post_Request()
    {
        TMP_InputField IF = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        question =IF.text;
        IF.text = "";
        StartCoroutine(Request());
    }
}

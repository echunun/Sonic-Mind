using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class Note2Screen : MonoBehaviour
{
    private string path;
    GameObject fr;//file_reader虽叫做fr，它还有创建文件的功能，作用是作为平台，把获取到的文本储存到新文件中
    // Start is called before the first frame update
    void Start()
    {
        //path = Application.persistentDataPath + "Users_Data/note/note_names.txt";//use path.combine
        path = Path.Combine(Application.persistentDataPath, "Users_Data", "note", "note_names.txt");
        fr= GameObject.Find("File_Reader");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Notes_Cont2Screen()
    {
        GameObject.Find("scene_manager").GetComponent<note_create>().Modify_Mode = true;
        Debug.Log("Modify Mode:"+GameObject.Find("scene_manager").GetComponent<note_create>().Modify_Mode);
        string[] names_and_path = File.ReadAllLines(path);
        foreach (var NPcont in names_and_path)
        {
            string[] NPconts = NPcont.Split('|');
            if (NPconts[0] == gameObject.GetComponentInChildren<TMP_Text>().text)
            {
                //Debug.Log("打开" + NPconts[0]);//成功
                //Debug.Log(Application.persistentDataPath + NPconts[1] + ".txt");
                if (File.Exists(Application.persistentDataPath+NPconts[1]+".txt"))
                {
                    string cont = File.ReadAllText(Application.persistentDataPath+ NPconts[1]+".txt");
                    
                    fr.GetComponent<TMP_InputField>().text = cont;
                    fr.GetComponent<Animator>().SetBool("is_appearing", true);
                    fr.GetComponent<Animator>().SetBool("is_disappearing", false);
                    GameObject.Find("ET_Placeholder").GetComponent<TMP_Text>().text = "";
                    GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text = "";
                    GameObject.Find("Title").GetComponent<TMP_Text>().text = NPconts[0];
                }
                else Debug.Log("File \""+ NPconts[0]+"\" Do not exist.");
            }
        }
    }
}

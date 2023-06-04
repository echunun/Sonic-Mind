using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
public class note_create : MonoBehaviour
{
    GameObject fr,title;
    Animator fr_ani;
    public bool Create_Mode=false, Modify_Mode = false;
    // Start is called before the first frame update
    void Start()
    {
        fr = GameObject.Find("File_Reader");
        fr_ani = fr.GetComponent<Animator>();
        title = GameObject.Find("Title");
        //Permission.RequestUserPermission(Permission.ExternalStorageRead);
        //Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            fr.GetComponent<Animator>().SetBool("is_disappearing", true);
            fr.GetComponent<Animator>().SetBool("is_appearing", false);
            //Debug.Log(fr.GetComponent<TMP_InputField>().text);
            if (Create_Mode){//如果是创建文件
                if( !string.IsNullOrEmpty(fr.GetComponent<TMP_InputField>().text)){
                    Debug.Log(Create_Mode);
                    //string filePath = Application.persistentDataPath + GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text+".txt";
                    string filePath = Path.Combine(Application.persistentDataPath, "Users_Data", "note", GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text + ".txt");
                    string Cont_in_NN = GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text + "|\\" + Path.Combine("Users_Data", "note", GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text);
                    string folderPath = Path.Combine(Application.persistentDataPath, "Users_Data", "note");
                    string NNPath = Path.Combine(folderPath, "note_names.txt");
                    //File.WriteAllLines(NNPath, new string[] { Cont_in_NN });用append！！
                    File.AppendAllLines(NNPath, new string[] { Cont_in_NN });
                    File.WriteAllText(filePath, fr.GetComponent<TMP_InputField>().text);
                    //Debug.Log("文件已保存");

                    //SceneManager.LoadScene("note");
                    GameObject.Find("scene_manager").GetComponent<test>().Notes_Name2Screen();
                }
                Set_Create_Mode_False();
            }
            if (Modify_Mode)//如果是修改文件
            {
                
                string filePath = Path.Combine(Application.persistentDataPath, "Users_Data", "note", GameObject.Find("Title").GetComponent<TMP_Text>().text + ".txt");
                string Cont_in_NN = GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text + "|\\" + Path.Combine("Users_Data", "note", GameObject.Find("Title_enter").GetComponent<TMP_InputField>().text);
                string folderPath = Path.Combine(Application.persistentDataPath, "Users_Data", "note");
                string NNPath = Path.Combine(folderPath, "note_names.txt");
                //File.WriteAllLines(NNPath, new string[] { Cont_in_NN });用append！！
                //File.AppendAllLines(NNPath, new string[] { Cont_in_NN });
                File.WriteAllText(filePath, fr.GetComponent<TMP_InputField>().text);
                Modify_Mode = false;
            }
            
        }
    }
    public void Create_new_note()
    {
        fr_ani.SetBool("is_appearing", true);
        fr_ani.SetBool("is_disappearing", false);
        title.GetComponent<TMP_Text>().text = "";//原标题清空
        fr.GetComponent<TMP_InputField>().text = "";//原内容清空
        GameObject.Find("ET_Placeholder").GetComponent<TMP_Text>().text = "Enter title";

        
    }
    public void Set_Create_Mode()
    {
        Create_Mode = true;
        Debug.Log("Create_Mode:true");
    }
    void Set_Create_Mode_False()
    {
        Create_Mode = false;
        Debug.Log("Create_Mode:fasle");
    }

}

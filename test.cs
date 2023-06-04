using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using TMPro;
//这个脚本有把储存的notes名字和索引弄到屏幕上的功能，其实应该叫Note_Names2Screen,至于为什么叫test是因为我从网站上学那个文件读取操作下的，然后就直接在这上面写了
public class test : MonoBehaviour
{
    public Text readText;
    private string path;
    private string path2;
    private string content;
    private string[] contents;
    public GameObject note_name;
    // Use this for initialization
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);//C:/Users/uuunnn/AppData/LocalLow/DefaultCompany/sonic mind

        content = "窗前明月光|疑是地上霜|举头望明月|低头思故乡|nima";
        contents = content.Split('|');
        

        string folderPath = Path.Combine(Application.persistentDataPath, "Users_Data", "note");
        string filePath = Path.Combine(folderPath, "note_names.txt");
        path2 = filePath;
        // 创建文件夹路径
        Directory.CreateDirectory(folderPath);
        if (!File.Exists(filePath))
        {
            // 创建空文件
            File.Create(filePath).Close();
        }
        Notes_Name2Screen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //写入数据
    public void WriteTxt()
    {
        if (!File.Exists(path))
        {

            //文本不存在创建文本
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8);
            foreach (var item in contents)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            fileStream.Close();

        }
        else
        {

        }
    }
    //读取数据
    public void ReadTxt()
    {
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            readText.text = sr.ReadToEnd();
            sr.Close();
        }
    }
    //删除文本
    public void DeleTxt()
    {
        FileInfo fileInfo = new FileInfo(path);
        fileInfo.Delete();

    }
    //拷贝文本
    public void CopyTxt()
    {
        if (File.Exists(path) && File.Exists(path2))
        {
            string content;
            StreamReader sr = new StreamReader(path);
            content = sr.ReadToEnd();
            StreamWriter sw = new StreamWriter(path2);
            sw.Write(content);
            sr.Close();
            sw.Close();
        }
    }
    public void Notes_Name2Screen()
    {
        //Debug.Log(path2);
        if (File.Exists(path2))
        {
            //Debug.Log("存在note_names");
            float pos_y = 700;
            string[] names_and_path = File.ReadAllLines(path2);
            foreach (var NPcont in names_and_path)
            {
                string[] NPconts = NPcont.Split('|');
                //Debug.Log(conts[0] + " "+conts[1]);//成功
                //然后我去instantiate一个按钮（注意位置），点击读取这个文件
                Vector3 pos = new Vector3(50, pos_y, 0);
                GameObject NN = Instantiate(note_name, GameObject.Find("main").transform);
                NN.GetComponent<RectTransform>().SetLocalPositionAndRotation(pos, Quaternion.identity);
                NN.GetComponentInChildren<TMP_Text>().text = NPconts[0];

                pos_y -= 200;
            }
        }
    }

}


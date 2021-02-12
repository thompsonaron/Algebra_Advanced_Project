using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Generator
{
    [MenuItem(itemName: "Generator/Generate UI")]
    public static void generate()
    {
        var filePath = Application.dataPath + "/UIGenerated" + SceneManager.GetActiveScene().name + ".cs";
        var canvas = GameObject.FindObjectOfType<Canvas>();
        var content = new List<string>();
        content.Add("using UnityEngine;");
        content.Add("public static class UIGenerated"+ SceneManager.GetActiveScene().name + "{");

        addUIData(canvas.gameObject, content);

        content.Add("");

        content.Add("\tpublic static void init() {");
        addUIInit(canvas.gameObject, content, "");
        content.Add("\t}");

        content.Add("}");

        File.WriteAllLines(filePath, content);

        AssetDatabase.Refresh();
    }

    public static void addUIData(GameObject go, List<string> content)
    {
        content.Add("\tpublic static GameObject " + go.name + ";");

        for (int i = 0; i < go.transform.childCount; i++)
        {
            addUIData(go.transform.GetChild(i).gameObject, content);
        }
    }

    public static void addUIInit(GameObject go, List<string> content, string prefix)
    {
        content.Add("\t\t" + go.name + " = GameObject.Find(\"" + prefix + go.name + "\");");

        for (int i = 0; i < go.transform.childCount; i++)   //in children we have Text
        {
            var newPrefix = prefix;
            if (newPrefix == "")
            {
                newPrefix = go.name + "/";
            }
            else
            {
                newPrefix += go.name + "/";
            }
            addUIInit(go.transform.GetChild(i).gameObject, content, newPrefix);
        }
    }
}
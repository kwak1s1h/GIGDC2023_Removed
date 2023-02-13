using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class SkillInstance : EditorWindow
{
    static string filePath = "Assets/01_Script/Gusdnd01/Skills";

    string skillName;
    static int skillIndex;
    bool isLocked;
    bool skillInstanceInputIsOpened;

    [MenuItem("Tools/MakeSkillSystem")]
    public static void ShowWindow()
    {
        EditorWindow wnd = GetWindow(typeof(SkillInstance));
        wnd.maxSize = new Vector2(400, 500);
        skillIndex = GetDirectoryCount();
    }

    private static int GetDirectoryCount()
    {
        int cnt = 0;
        try
        {
            if (Directory.Exists(filePath))
            {
                DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(filePath);
                cnt = directoryInfo.GetFiles().Length;
            }

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            AssetDatabase.CreateFolder("Assets/01_Scripts/Gusdnd01", "Skills");
        }
        return cnt;
    }

    private bool FolderExists()
    {
        if (Directory.Exists(filePath))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginToggleGroup("Skill Folder", FolderExists());
        if (GUILayout.Button("Create Skill Folder"))
        {
            //Create Folder
        }
        EditorGUILayout.EndToggleGroup();

        GUILayout.Label($"Index of present skill: {skillIndex}", EditorStyles.boldLabel);
        GUILayout.Space(5);
        GUILayout.Label("Input skill data");
        skillInstanceInputIsOpened = EditorGUILayout.BeginToggleGroup("Skill Input", skillInstanceInputIsOpened);
        skillName = EditorGUILayout.TextField("Skill name", skillName);
        isLocked = EditorGUILayout.Toggle("Skill Locked", isLocked);
        EditorGUILayout.EndToggleGroup();
        string name = skillName.Replace(" ", "_");
        string copyPath = filePath + $"/{name}.cs";
        if (GUILayout.Button("Create Skill Script") && skillName != null)
        {
            if (File.Exists(copyPath) == false)
            {
                using (StreamWriter outfile =
                    new StreamWriter(copyPath))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("");
                    outfile.WriteLine($"public class {skillName} : SkillBase {{");
                    outfile.WriteLine("\t"+"protected override void Reset(){");
                    outfile.WriteLine("\t"+"\t" + $"skillIndex = {skillIndex};");
                    outfile.WriteLine("\t"+"}");
                    outfile.WriteLine(" ");
                    outfile.WriteLine("\t"+"public override void Skill(){");
                    outfile.WriteLine("\t"+"\t"+"if(!isLocked){");
                    outfile.WriteLine("\t"+"\t\t"+"//스킬 내용 구성 적어주고");
                    outfile.WriteLine("\t"+"\t\t"+"btn.interactable = true;");
                    outfile.WriteLine("\t"+"\t"+"}");
                    outfile.WriteLine("\t"+"\t"+"else{");
                    outfile.WriteLine("\t"+"\t"+"\t"+"btn.interactable = false;");
                    outfile.WriteLine("\t"+"\t"+"}");
                    outfile.WriteLine("\t"+"}");
                    outfile.WriteLine("}");
                }//File written
            }
            AssetDatabase.Refresh();
        }
    }
}

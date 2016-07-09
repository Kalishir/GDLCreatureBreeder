using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EditorRenameFiles : EditorWindow
{

    string stringToReplace = "";
    string stringToReplaceWith = "";
    List<string> filesToRename = new List<string>(); 


    bool groupEnabled;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Editor Scripts/Rename Files")]
    static void Init()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(EditorRenameFiles));
    }

    void OnGUI()
    {
        

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        stringToReplace = EditorGUILayout.TextField("Text to replace", stringToReplace);
        stringToReplaceWith = EditorGUILayout.TextField("Text after Replacement", stringToReplaceWith);

        /*groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();*/

        if (GUILayout.Button("Replace files"))
        {
            filesToRename.Clear();


            //All files selected
            var assetFiles = GetFiles(GetSelectedPathOrFallback()).Where(s => s.Contains(".meta") == false);
            foreach (var derp in assetFiles)
            {
                if(Path.GetFileName(derp).Contains(stringToReplace))
                {
                    filesToRename.Add(derp);
                }
            }
            foreach (var file in filesToRename)
            {
                
                //TODO make it so you can undo your changes

                //Get the assets name
                var assetName = Path.GetFileName(file);

                //Replace the assets name
                var tempName = assetName.Replace(stringToReplace, stringToReplaceWith);

                //rename the asset to what we set it
                AssetDatabase.RenameAsset(file, tempName);
            }
        }
    }



    /// <summary>
    /// Retrieves selected folder on Project view.
    /// </summary>
    /// <returns></returns>
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";

        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }

    /// <summary>
    /// Recursively gather all files under the given path including all its subfolders.
    /// </summary>
    static IEnumerable<string> GetFiles(string path)
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(path);
        while (queue.Count > 0)
        {
            path = queue.Dequeue();
            try
            {
                foreach (string subDir in Directory.GetDirectories(path))
                {
                    queue.Enqueue(subDir);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            string[] files = null;
            try
            {
                files = Directory.GetFiles(path);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    yield return files[i];
                }
            }
        }
    }
    
    /*
    // You can either filter files to get only neccessary files by its file extension using LINQ.
    // It excludes .meta files from all the gathers file list.
    var assetFiles = GetFiles(GetSelectedPathOrFallback()).Where(s => s.Contains(".meta") == false);
  
     foreach (string f in assetFiles)
     {
       Debug.Log("Files: " + f);
     }*/
}

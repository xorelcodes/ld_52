using UnityEngine;
using UnityEditor;

public static class QuitApplication
{
    public static void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class MyCustomBuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder => 1;
    public void OnPreprocessBuild(BuildReport report)
    {
        System.Environment.SetEnvironmentVariable("EMSDK_PYTHON", "/usr/local/Cellar/python@3.9/3.9.4/Frameworks/Python.framework/Versions/3.9/bin/python3.9");
    }
}
#endif
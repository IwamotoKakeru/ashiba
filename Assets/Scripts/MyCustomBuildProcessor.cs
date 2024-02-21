#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>
/// MacでWebGLビルドが通らないことへの対策
/// macOS12.3からPython2.7が削除されたため、Python3.9へパスを通している
/// </summary>
/// <seealso href="https://forum.unity.com/threads/case-1412113-builderror-osx-12-3-and-unity-2020-3-constant-build-errors.1255419/">
/// Unity Forum
/// </seealso>
/// 実装:岩本
public class MyCustomBuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder => 1;
    public void OnPreprocessBuild(BuildReport report)
    {
        System.Environment.SetEnvironmentVariable("EMSDK_PYTHON", "/usr/local/Cellar/python@3.9/3.9.4/Frameworks/Python.framework/Versions/3.9/bin/python3.9");
    }
}
#endif
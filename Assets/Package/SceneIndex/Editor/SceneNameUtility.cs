
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public static class SceneNameUtility
{
  [InitializeOnLoadMethod]
  [MenuItem("Editor Tools/Update Scene Index")]
  static void Update()
  {
    sceneNames = GetSceneNames();
    UnityEngine.Debug.Log("シーンのインデックス情報を更新しました");
  }


  /// <summary> ビルド対象として有効なシーン名の一覧 </summary>
  public static string[] sceneNames { get; private set; }

  public static bool existsName { get { return sceneNames.Any(); } }

  /// <summary> 一致したビルド対象シーンのインデックスを返す </summary>
  public static int GetSceneIndex(string name)
  {
    int i = 0;

    for (int length = sceneNames.Length; i < length; ++i)
    {
      if ( sceneNames[i] == name ) { break; }
    }

    return i;
  }


  static string[] GetSceneNames()
  {
    var scenes = EditorBuildSettings.scenes.Where( scene => scene.enabled );
    return ReplaceNames( scenes.Select( scene => scene.path ) );
  }

  static readonly string root = "Assets/";
  static readonly string extension = ".unity";

  // TIPS:
  // プロジェクト内にあるシーンファイルのパスから、ルートフォルダと拡張子を除外
  //
  // ex) Assets/_TEST/_TEST_1.unity -> _TEST/_TEST_1
  //
  static string[] ReplaceNames(IEnumerable<string> paths)
  {
    var names = paths.Select( path => path.Replace( root, string.Empty ) );
    return names.Select( name => name.Replace( extension, string.Empty ) ).ToArray();
  }
}

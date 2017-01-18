
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CustomPropertyDrawer( typeof( SceneIndex ) )]
public sealed class SceneNameDrawer : PropertyDrawer
{
  public override void OnGUI(Rect position,
                             SerializedProperty property,
                             GUIContent label)
  {
    if ( !SceneNameUtility.existsName ) { EmptyField( position, property ); return; }

    var name = property.FindPropertyRelative("_name");

    int oldIndex = SceneNameUtility.GetSceneIndex( name.stringValue );
    int newIndex = PopupField( position, oldIndex, label.text );

    if ( !GUI.changed ) { return; }

    if ( oldIndex != newIndex )
    {
      var number = property.FindPropertyRelative("_number");
      number.intValue = newIndex;

      name.stringValue = SceneNameUtility.sceneNames[ newIndex ];
    }
  }


  static void EmptyField(Rect position, SerializedProperty property)
  {
    string label = ObjectNames.NicifyVariableName( property.name );
    EditorGUI.LabelField( position, label, "scene is not found." );
  }

  static int PopupField(Rect position, int selected, string label)
  {
    string[] names = SceneNameUtility.sceneNames;
    int[] indices = names.Select( ( name, index ) => index ).ToArray();
    return EditorGUI.IntPopup( position, label, selected, names, indices );
  }
}

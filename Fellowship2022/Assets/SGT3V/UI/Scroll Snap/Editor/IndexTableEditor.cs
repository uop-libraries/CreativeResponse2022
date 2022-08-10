using UnityEditor;
using UnityEngine;
using SGT3V.Common;
using UnityEngine.UI;

namespace SGT3V.UI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(IndexTable))]
    public class IndexTableEditor : Editor
    {
        private const string TogglePrefabName = "Toggle";
        private const string IndexTablePrefabName = "Index Table";

        private readonly GUIContent SnapScrollLabel = new GUIContent("ScrollSnap", "ScrollSnap stuff.");
        private readonly GUIContent ToggleSizeLabel = new GUIContent("ToggleSizeLabel", "ToggleSizeLabel stuff.");
        private readonly GUIContent TogglePaddingLabel = new GUIContent("TogglePaddingLabel", "TogglePaddingLabel stuff.");

        private SerializedProperty ScrollSnap; 
        private SerializedProperty ToggleSize;
        private SerializedProperty TogglePadding;

        private void OnEnable()
        {
            ScrollSnap = serializedObject.FindProperty("ScrollSnap");
            ToggleSize = serializedObject.FindProperty("ToggleSize");
            TogglePadding = serializedObject.FindProperty("TogglePadding");
        }

        [MenuItem("GameObject/UI/Index Table", false)]
        private static void AddIndexTable()
        {
            EditorUtilities.CreateInCanvas<IndexTable>(IndexTablePrefabName, (canvas, table) => {
                table.ToggleSize = 30;
                table.TogglePadding = 5;
            });
        }

        public override void OnInspectorGUI()
        {
            IndexTable indexTable = target as IndexTable;
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(ScrollSnap, SnapScrollLabel);
            if (EditorGUI.EndChangeCheck())
            {
                ScrollSnap scrollSnap = ScrollSnap.objectReferenceValue as ScrollSnap;
                OnTableCreated(scrollSnap, indexTable);
                OnToggleSizeChanged(indexTable);
            }

            if(ScrollSnap.objectReferenceValue != null)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(ToggleSize, ToggleSizeLabel);
                if (EditorGUI.EndChangeCheck())
                {
                    OnToggleSizeChanged(indexTable);
                }

                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(TogglePadding, TogglePaddingLabel);
                if (EditorGUI.EndChangeCheck())
                {
                    OnToggleSizeChanged(indexTable);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void OnTableCreated(ScrollSnap scrollSnap, IndexTable table)
        {
            table.transform.DestroyChildren();

            if (scrollSnap == null) return;

            int pageCount = scrollSnap.Content.childCount;
            (table.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pageCount * ToggleSize.floatValue);

            if (scrollSnap != null)
            {
                ToggleGroup toggleGroup = table.GetComponent<ToggleGroup>();

                for (int i = 0; i < pageCount; i++)
                {
                    int index = i;

                    Toggle toggle = EditorUtilities.LoadAndInstantiate<Toggle>(TogglePrefabName, table.transform);
                    (toggle.transform as RectTransform).anchoredPosition = new Vector2(index * 50, 0);
                    toggle.group = toggleGroup;
                    toggle.isOn = index == 0;
                }
            }
        }

        private void OnToggleSizeChanged(IndexTable table)
        {
            Toggle[] toggles = table.GetComponentsInChildren<Toggle>();

            for (int i = 0; i < toggles.Length; i++)
            {
                (toggles[i].transform as RectTransform).anchoredPosition = new Vector2(i * (ToggleSize.floatValue + TogglePadding.floatValue), 0);
                (toggles[i].transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ToggleSize.floatValue);
                (toggles[i].transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ToggleSize.floatValue);
            }

            (table.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (toggles.Length) * (ToggleSize.floatValue + TogglePadding.floatValue) - TogglePadding.floatValue);
            (table.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ToggleSize.floatValue);
        }
    }
}

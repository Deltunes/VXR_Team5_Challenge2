using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class FixCondoMaterials
{
    [MenuItem("Tools/Fix Condo Materials")]
    static void Fix()
    {
        var lookup = new Dictionary<string, Material>();
        foreach (var guid in AssetDatabase.FindAssets("t:Material", new[] { "Assets/Japanese Condo/Materials" }))
        {
            var m = AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(guid));
            if (m != null) lookup[m.name] = m;
        }

        int swapped = 0, skipped = 0;
        foreach (var r in Object.FindObjectsByType<Renderer>(FindObjectsInactive.Include))
        {
            var mats = r.sharedMaterials;
            bool changed = false;
            for (int i = 0; i < mats.Length; i++)
            {
                if (mats[i] == null) { skipped++; continue; }
                if (lookup.TryGetValue(mats[i].name, out var good) && mats[i] != good)
                {
                    mats[i] = good;
                    changed = true;
                    swapped++;
                }
            }
            if (changed)
            {
                Undo.RecordObject(r, "Fix Condo Materials");
                r.sharedMaterials = mats;
                EditorUtility.SetDirty(r);
            }
        }
        EditorSceneManager.MarkAllScenesDirty();
        Debug.Log("Fix Condo Materials: swapped " + swapped + " slots, skipped " + skipped + " empty (Missing) slots.");
    }
}
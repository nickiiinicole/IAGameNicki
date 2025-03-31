namespace CharactersZombieHospitalLowpolyPackLite
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.TextCore.Text;

    public class RateAssetPopup : EditorWindow
    {
        private string assetName = "3D Characters Zombie Hospital Lowpoly Pack - Lite";
        private string rateUrl = "https://assetstore.unity.com/packages/3d/characters/3d-characters-zombie-hospital-lowpoly-pack-lite-274047#reviews";
        private string preferenceKey;

        private Texture2D yesIcon;
        private Texture2D noIcon;
        private Texture2D cancelIcon;

        [InitializeOnLoadMethod]
        private static void InitOnUnityStart()
        {
            EditorApplication.update += ShowOnStartup;
        }

        private static void ShowOnStartup()
        {
            EditorApplication.update -= ShowOnStartup;

            // Set a unique preference key based on the asset name
            string preferenceKey = "RatedAsset_" + "3D Characters Zombie Hospital Lowpoly Pack - Lite".Replace(" ", "_");

            // Only show the popup if it hasn't been rated before
            if (!PlayerPrefs.HasKey(preferenceKey) && Random.Range(0, 100) < 30)
            {
                ShowWindow("3D Characters Zombie Hospital Lowpoly Pack - Lite");
            }
        }

        public static void ShowWindow(string assetName)
        {
            var window = GetWindow<RateAssetPopup>(true, assetName, true);
            window.minSize = new Vector2(400, 150);
            window.maxSize = new Vector2(500, 150);
            window.assetName = assetName;
            window.preferenceKey = "RatedAsset_" + assetName.Replace(" ", "_");

            if (!PlayerPrefs.HasKey(window.preferenceKey))
            {
                window.Show();
            }
        }

        private void OnEnable()
        {
            yesIcon = Resources.Load<Texture2D>("Yes");
            noIcon = Resources.Load<Texture2D>("No");
            cancelIcon = Resources.Load<Texture2D>("Cancel");
        }

        private void OnGUI()
        {
            GUILayout.Space(10f);
            GUILayout.Label("Leave a Rating?", EditorStyles.boldLabel);
            GUILayout.Space(10f);
            GUILayout.Label($"If you enjoy \"{assetName}\",");
            GUILayout.Label("please take a moment to rate the asset.\n\nThank you for your support!");
            GUILayout.Space(10);

            GUILayout.BeginHorizontal();

            // "Sure!" button with icon
            if (GUILayout.Button(new GUIContent("     Sure!", yesIcon)))
            {
                Application.OpenURL(rateUrl);
                PlayerPrefs.SetInt(preferenceKey, 1);
                PlayerPrefs.Save(); // Save immediately after setting
                Close();
            }

            // "Never" button with icon
            if (GUILayout.Button(new GUIContent("     Never", noIcon)))
            {
                PlayerPrefs.SetInt(preferenceKey, 1);
                PlayerPrefs.Save(); // Save immediately after setting
                Close();
            }

            // "Cancel" button with icon
            if (GUILayout.Button(new GUIContent("     Cancel", cancelIcon)))
            {
                Close();
            }

            GUILayout.EndHorizontal();
        }
    }
#endif
}


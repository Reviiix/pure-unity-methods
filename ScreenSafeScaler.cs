using UnityEngine;
using UnityEngine.SceneManagement;

namespace PureFunctions.UnitySpecific
{
    [ExecuteInEditMode]
    public class ScreenSafeScaler : MonoBehaviour
    {
        private bool initialised;
        private bool rescalingInProgress;
        [SerializeField] private Canvas canvas;
        [SerializeField] private bool ignoreLeft;
        [SerializeField] private bool ignoreRight;
        [SerializeField] private bool ignoreTop;
        [SerializeField] private bool ignoreBottom;
        private RectTransform panelSafeArea;
        private Rect currentSafeArea;
        private ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;
    
        private void Awake()
        {
            if (initialised) return;
            Initialise();
            ApplySafeArea();
        }

        private void Initialise()
        {
            panelSafeArea = canvas.GetComponent<RectTransform>();
            currentOrientation = Screen.orientation;
            currentSafeArea = Screen.safeArea;
            initialised = true;
        }

        private void OnValidate()
        {
            ApplySafeArea();
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneChange;
        }
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneChange;
        }

        private void ApplySafeArea()
        {
            if (!initialised) return;
            if (rescalingInProgress) return;
            
            rescalingInProgress = true;
            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;
            var pixelRect = canvas.pixelRect;
            
            anchorMin.x /= pixelRect.width;
            anchorMin.y /= pixelRect.height;
            anchorMax.x /= pixelRect.width;
            anchorMax.y /= pixelRect.height;

            if (ignoreLeft)
            {
                anchorMin.x = panelSafeArea.anchorMin.x;
            }
            if (ignoreRight)
            {
                anchorMax.x = panelSafeArea.anchorMax.x;
            }
            if (ignoreBottom)
            {
                anchorMax.y = panelSafeArea.anchorMax.y;
            }
            if (ignoreTop)
            {
                anchorMin.y = panelSafeArea.anchorMin.y;
            }

            panelSafeArea.anchorMin = anchorMin;
            panelSafeArea.anchorMax = anchorMax;
            panelSafeArea.anchoredPosition = Vector2.zero;
            panelSafeArea.sizeDelta = Vector2.zero;
            currentOrientation = Screen.orientation;
            currentSafeArea = safeArea;
            
            rescalingInProgress = false;
        }
        
        [ContextMenu(nameof(UpdateScreenSafeArea))]
        private void UpdateScreenSafeArea()
        {
            if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea)
            {
                ApplySafeArea();
            }
        }
        
        private void OnSceneChange(Scene _, LoadSceneMode __)
        {
            ApplySafeArea();
        }
    }
}
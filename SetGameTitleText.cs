using TMPro;
using UnityEditor;
using UnityEngine;

namespace pure_unity_methods
{
    /// <summary>
    /// This class gets the product name from the player settings and displays it in the required component, TMP_Text.
    /// Can choose to capitalise.
    /// The class will then remove itself as its no longer needed.
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class SetGameTitleText : MonoBehaviour
    {
        [SerializeField] private bool capitalise;
        
        private void Awake()
        {
            GetComponent<TMP_Text>().text = capitalise ? PlayerSettings.productName.ToUpper() : PlayerSettings.productName;
            Destroy(this);
        }
    }
}

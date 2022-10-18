using TMPro;
using UnityEditor;
using UnityEngine;

namespace PureFunctions
{
    [RequireComponent(typeof(TMP_Text))]
    public class SetGameTitleText : MonoBehaviour
    {
        [SerializeField] private bool capitalise;
        
        private void Awake()
        {
            GetComponent<TMP_Text>().text = capitalise ? PlayerSettings.productName.ToUpper() : PlayerSettings.productName;
            Destroy(GetComponent<SetGameTitleText>());
        }
    }
}

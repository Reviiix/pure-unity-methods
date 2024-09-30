using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace pure_unity_methods
{
    /// <summary>
    /// This class gets the scene name from the scene manager  and displays it in the required component, TMP_Text.
    /// Can choose to capitalise.
    /// The class will then remove itself as its no longer needed.
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class SetSceneNameText : MonoBehaviour
    {
        [SerializeField] private bool capitalise;
        
        private void Awake()
        {
            GetComponent<TMP_Text>().text = capitalise ? SceneManager.GetActiveScene().name.ToUpper() : SceneManager.GetActiveScene().name;
            Destroy(this);
        }
    }
}
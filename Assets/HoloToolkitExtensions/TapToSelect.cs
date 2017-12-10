using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class TapToSelect : MonoBehaviour, IInputClickHandler
    {
        public GameObject forceps;

        public virtual void OnInputClicked(InputEventData eventData)
        {
            if (BaseAppStateManager.IsInitialized)
            {
                // If not already selected - select, otherwise, deselect
                if (BaseAppStateManager.Instance.SelectedGameObject != gameObject)
                {
                    BaseAppStateManager.Instance.SelectedGameObject = gameObject;
                    //if it is not a human
                    if (BaseAppStateManager.Instance.SelectedGameObject != GameObject.Find("HuMan"))
                    {
                        //if child count is greater than 0 AND the text is Forceps
                        if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Forceps")
                        {
                            // make a forceps and add it to the collection
                            forceps = Instantiate(forceps);
                            forceps.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                    }
                }
                else
                {
                    BaseAppStateManager.Instance.SelectedGameObject = null;
                }
                var audioSource = GetAudioSource(gameObject);
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
            else
            {
                Debug.Log("No BaseAppStateManager found or initialized");
            }
        }

        private AudioSource GetAudioSource(GameObject obj)
        {
            var audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.GetComponentInParent<AudioSource>();
            }
            return audioSource;
        }
    }
}

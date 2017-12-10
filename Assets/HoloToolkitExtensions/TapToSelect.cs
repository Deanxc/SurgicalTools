using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class TapToSelect : MonoBehaviour, IInputClickHandler
    {
        public GameObject forceps;
        public GameObject graspingForceps;
        public GameObject lancet;
        public GameObject scissors;
        public GameObject surgicalMirror;
        public GameObject surgicalSaw;
        public GameObject surgicalHook;
        public GameObject syringe;

        public virtual void OnInputClicked(InputEventData eventData)
        {
            if (BaseAppStateManager.IsInitialized)
            {
                // If not already selected - select, otherwise, deselect
                if (BaseAppStateManager.Instance.SelectedGameObject != gameObject)
                {
                    BaseAppStateManager.Instance.SelectedGameObject = gameObject;
                    //if it is not a human
                    //BaseAppStateManager.Instance.SelectedGameObject != GameObject.Find("HuMan") &&
                    //    BaseAppStateManager.Instance.SelectedGameObject != GameObject.Find("Grasping_forceps") &&
                    //    BaseAppStateManager.Instance.SelectedGameObject != GameObject.Find("Syringe") &&
                    //    BaseAppStateManager.Instance.SelectedGameObject != GameObject.Find("Scissors")
                    if (BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (1)") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (2)") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (3)") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (4)") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (5)") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (6)") ||
                        BaseAppStateManager.Instance.SelectedGameObject == GameObject.Find("Cube (7)"))
                    {
                        var menuPos = GameObject.Find("MenuParent").transform.position;
                        var spawnPos = new Vector3(menuPos.x, menuPos.y + 0.5f, menuPos.z);
                        //if child count is greater than 0 AND the text is Forceps
                        if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Forceps")
                        {
                            // make a forceps and add it to the collection
                            //get menu pos
                            //var menuPos = GameObject.Find("MenuParent").transform.position;
                            //get position we want for forceps
                            //var spawnPos = new Vector3(menuPos.x, menuPos.y + 0.5f, menuPos.z);

                            forceps = Instantiate(forceps, spawnPos, Quaternion.identity);
                            forceps.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Lancet")
                        {
                            // make a forceps and add it to the collection
                            lancet = Instantiate(lancet, spawnPos, Quaternion.identity);
                            lancet.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Scissors")
                        {
                            // make a forceps and add it to the collection
                            scissors = Instantiate(scissors, spawnPos, Quaternion.identity);
                            scissors.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Syringe")
                        {
                            // make a forceps and add it to the collection
                            syringe = Instantiate(syringe, spawnPos, Quaternion.identity);
                            syringe.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Grasping")
                        {
                            // make a forceps and add it to the collection
                            graspingForceps = Instantiate(graspingForceps, spawnPos, Quaternion.identity);
                            graspingForceps.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 1 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(1).GetComponent<TextMesh>().text == "hook")
                        {
                            // make a forceps and add it to the collection
                            surgicalHook = Instantiate(surgicalHook, spawnPos, Quaternion.identity);
                            surgicalHook.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 1 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(1).GetComponent<TextMesh>().text == "mirror")
                        {
                            // make a forceps and add it to the collection
                            surgicalMirror = Instantiate(surgicalMirror, spawnPos, Quaternion.identity);
                            surgicalMirror.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 1 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(1).GetComponent<TextMesh>().text == "saw")
                        {
                            // make a forceps and add it to the collection
                            surgicalSaw = Instantiate(surgicalSaw, spawnPos, Quaternion.identity);
                            surgicalSaw.transform.parent = GameObject.Find("HologramCollection").transform;
                        }
                        else { }
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

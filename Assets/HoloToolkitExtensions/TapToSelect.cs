using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class TapToSelect : MonoBehaviour, IInputClickHandler
    {


        //public GameObject human;
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

                    //////////////////////////////////////////////////////////////////////////////////////
                    if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 0) 
                    {
                        if (BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Forceps")
                        {
                            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            //cube.transform.position = new Vector3(0, 0, 0);

                            //forceps.transform.position = new Vector3(2, 0, 2);
                            //forceps.transform.localScale = new Vector3(2, 2, 2);

                            forceps = Instantiate(forceps, new Vector3(-4, 1, 2), Quaternion.identity) as GameObject;

                            //forceps.AddComponent<BoxCollider>();
                            //forceps.AddComponent<SpatialManipulator>();
                            //forceps.AddComponent<SpatialMappingCollisionDetector>();
                            //forceps.AddComponent<TapToSelect>();
                            //forceps.AddComponent<HandDraggable>();
                            //forceps.AddComponent<GazeManager>();
                            //forceps.AddComponent<MeshFilter>();
                            //forceps.AddComponent<MeshRenderer>();



                            
                        }
                        else if(BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Grasping")
                        {
                            //graspingForceps.transform.position = new Vector3(2, 0, 2);
                            //graspingForceps.transform.localScale = new Vector3(2, 2, 2);

                            Instantiate(graspingForceps);

                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Lancet")
                        {
                            Instantiate(lancet);
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Scissors")
                        {
                            Instantiate(scissors);
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 1 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(1).GetComponent<TextMesh>().text == "hook")
                        {
                            Instantiate(surgicalHook);
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 1 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(1).GetComponent<TextMesh>().text == "mirror")
                        {
                            Instantiate(surgicalMirror);
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.childCount > 1 &&
                            BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(1).GetComponent<TextMesh>().text == "saw")
                        {
                            Instantiate(surgicalSaw);
                        }
                        else if (BaseAppStateManager.Instance.SelectedGameObject.transform.GetChild(0).GetComponent<TextMesh>().text == "Syringe")
                        {
                            Instantiate(syringe);
                        }
                        else
                        {
                            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            sphere.transform.position = new Vector3(0, 0, 0);
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

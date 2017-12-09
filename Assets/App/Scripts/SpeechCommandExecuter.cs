using UnityEngine;
using HoloToolkit.Unity.InputModule;
using LocalJoost.HoloToolkitExtensions;

public class SpeechCommandExecuter : MonoBehaviour
{
    public bool IsActive = false;

    private AudioSource _sound;

    void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    public void Move()
    {
        AppStateManager.Instance.SelectedGameObject.GetComponent<HandDraggable>().enabled = true;
        TryChangeMode(ManipulationMode.Move);
    }

    public void Rotate()
    {
        AppStateManager.Instance.SelectedGameObject.GetComponent<HandDraggable>().enabled = false;
        TryChangeMode(ManipulationMode.Rotate);
    }

    public void Scale()
    {
        AppStateManager.Instance.SelectedGameObject.GetComponent<HandDraggable>().enabled = false;
        TryChangeMode(ManipulationMode.Scale);
    }

    public void Done()
    {
        //AppStateManager.Instance.SelectedGameObject.GetComponent<HandDraggable>().enabled = false;
        TryChangeMode(ManipulationMode.None);
    }

    public void Delete()
    {
        AppStateManager.Instance.SelectedGameObject.GetComponent<HandDraggable>().enabled = false;
        TryChangeMode(ManipulationMode.Delete);
    }

    public void Faster()
    {
        TryChangeSpeed(true);
    }

    public void Slower()
    {
        TryChangeSpeed(false);
    }

    private void TryChangeMode(ManipulationMode mode)
    {
        var manipulator = GetSpatialManipulator();
        if (manipulator == null)
        {
            return;
        }

        if (manipulator.Mode != mode)
        {
            manipulator.Mode = mode;
            TryPlaySound();
        }
    }

    private void TryChangeSpeed(bool faster)
    {
        var manipulator = GetSpatialManipulator();
        if (manipulator == null)
        {
            return;
        }

        if (manipulator.Mode == ManipulationMode.None)
        {
            return;
        }

        if (faster)
        {
            manipulator.Faster();
        }
        else
        {
            manipulator.Slower();

        }
        TryPlaySound();

    }

    private void TryPlaySound()
    {
        if (_sound != null && _sound.clip != null)
        {
            _sound.Play();
        }
    }


    private SpatialManipulator GetSpatialManipulator()
    {
        var lastSelectedObject = AppStateManager.Instance.SelectedGameObject;
        if (lastSelectedObject == null)
        {
            Debug.Log("No selected element found");
            return null;
        }
        var manipulator = lastSelectedObject.GetComponent<SpatialManipulator>();
        if (manipulator == null)
        {
            manipulator = lastSelectedObject.GetComponentInChildren<SpatialManipulator>();
        }

        if (manipulator == null)
        {
            Debug.Log("No manipulator component found");
        }
        return manipulator;
    }
}

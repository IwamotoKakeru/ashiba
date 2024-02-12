using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour, IPointerDownHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

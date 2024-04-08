using UnityEngine;

namespace Client.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}
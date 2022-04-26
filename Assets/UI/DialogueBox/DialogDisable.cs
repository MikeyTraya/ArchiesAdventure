using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class DialogDisable : MonoBehaviour
    {
        public enum State
        {
            MainGame,
            Tutorial,
        }

        public State state;

        [SerializeField] private GameObject dialogBox;
        public float textDuration;

        private void OnEnable()
        {
            switch (state)
            {
                case State.MainGame:
                    dialogBox.SetActive(false);
                    break;
                case State.Tutorial:
                    StartCoroutine(HideDialogBox());
                    break;
                default:
                    break;
            }
        }

        IEnumerator HideDialogBox()
        {
            yield return new WaitForSeconds(textDuration);
            dialogBox.SetActive(false);
        }
    }
}

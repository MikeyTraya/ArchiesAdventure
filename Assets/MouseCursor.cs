using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarriorOrigins
{
    public class MouseCursor : MonoBehaviour
    {
        public enum State
        {
            MainMenu,
            Game,
        }

        public State state;

        public SpriteRenderer spriteRenderer;
        public Sprite spriteMouse1;
        public Sprite spriteMouse2;
        public Sprite gameCursor;

        void Start()
        {
            Cursor.visible = false;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            switch (state)
            {
                case State.MainMenu:
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (spriteRenderer.sprite != spriteMouse2)
                        {
                            spriteRenderer.sprite = spriteMouse2;
                        }
                        else
                        {
                            spriteRenderer.sprite = spriteMouse1;
                        }
                    }else if (Input.GetMouseButtonUp(0))
                    {
                        spriteRenderer.sprite = spriteMouse1;
                    }
                    break;
                case State.Game:
                    spriteRenderer.sprite = gameCursor;
                    break;
                default:
                    break;
            }

            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;

        }

        
    }
}

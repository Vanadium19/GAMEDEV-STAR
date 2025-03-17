using UnityEngine;

namespace Game.Menu.UI
{
    public class CursorChanger : ICursorChanger
    {
        private readonly Texture2D _cursorTexture;

        public CursorChanger(Texture2D cursorTexture)
        {
            _cursorTexture = cursorTexture;
        }

        public void SetAimCursor()
        {
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
        }

        public void SetDefaultCursor()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
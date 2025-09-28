using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerInventoryUI : MonoBehaviour
    {
        private static GUIStyle _labelStyle;
        [SerializeField] private Rect rect = new(10, 500, 300, 300);
        private string _label;
        private GUIContent _labelContent;

        private void OnGUI()
        {
            _label = ServiceLocator<PlayerInventory>.Service?.GetAsString();
            if (_label == null) return;
            if (Event.current.type != EventType.Repaint)
                return;

            // If we have a parent, offset our rect by the parent.
            // if (m_Parent != null)
            //     rect.position += m_Parent.m_Rect.position;

            // if (m_Visualizer != null)
            //     m_Visualizer.OnDraw(rect);
            // else
            //     VisualizationHelpers.DrawRectangle(rect, new Color(1, 1, 1, 0.1f));

            // Draw label, if we have one.
            if (string.IsNullOrEmpty(_label)) return;
            _labelContent = new GUIContent(_label);
            _labelStyle = new GUIStyle
            {
                normal =
                {
                    textColor = Color.white
                }
            };

            ////FIXME: why does CalcSize not calculate the rect width correctly?
            var labelSize = _labelStyle.CalcSize(_labelContent);
            var labelRect = new Rect(rect.x + 4, rect.y, labelSize.x + 4, rect.height);

            _labelStyle.Draw(labelRect, _labelContent, false, false, false, false);
        }
    }
}
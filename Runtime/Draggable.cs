using UnityEngine;
using UnityEngine.EventSystems;

namespace Kogane.Internal
{
    /// <summary>
    /// UI をドラッグできるようにするコンポーネント
    /// </summary>
    [AddComponentMenu( "" )]
    [DisallowMultipleComponent]
    internal sealed class Draggable :
        MonoBehaviour,
        IDragHandler
    {
        //====================================================================================
        // 変数(SerializeField)
        //====================================================================================
        [SerializeField][HideInInspector] private RectTransform m_rectTransform;

        //====================================================================================
        // 関数
        //====================================================================================
        /// <summary>
        /// リセットされる時に呼び出されます
        /// </summary>
        private void Reset()
        {
            m_rectTransform = GetComponent<RectTransform>();
        }

        /// <summary>
        /// ドラッグ中に呼び出されます
        /// </summary>
        void IDragHandler.OnDrag( PointerEventData e )
        {
            m_rectTransform.position += new Vector3( e.delta.x, e.delta.y, 0f );
        }
    }
}
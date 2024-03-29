﻿using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// FPS を計測する構造体
    /// </summary>
    internal sealed class FPSCounter
    {
        //====================================================================================
        // 定数
        //====================================================================================
        private const float INTERVAL = 0.5f;

        //====================================================================================
        // 変数
        //====================================================================================
        private float m_accum;
        private int   m_frames;
        private float m_timeleft;

        //====================================================================================
        // プロパティ
        //====================================================================================
        public float Fps { get; private set; }

        //====================================================================================
        // 関数
        //====================================================================================
        /// <summary>
        /// 更新する時に呼び出します
        /// </summary>
        public void Update()
        {
            m_timeleft -= Time.deltaTime;
            m_accum    += Time.timeScale / Time.deltaTime;
            m_frames++;

            if ( 0 < m_timeleft ) return;

            Fps        = m_accum / m_frames;
            m_timeleft = INTERVAL;
            m_accum    = 0;
            m_frames   = 0;
        }
    }
}
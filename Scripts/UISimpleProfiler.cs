using System;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

namespace Kogane.Internal
{
	/// <summary>
	/// シンプルなプロファイラの UI を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	internal sealed class UISimpleProfiler : MonoBehaviour
	{
		//====================================================================================
		// 定数
		//====================================================================================
		private const float INTERVAL = 0.5f;

		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private TMP_Text m_fpsTextUI        = default;
		[SerializeField] private TMP_Text m_gcTextUI         = default;
		[SerializeField] private TMP_Text m_monoUsedTextUI   = default;
		[SerializeField] private TMP_Text m_monoTotalTextUI  = default;
		[SerializeField] private TMP_Text m_unityUsedTextUI  = default;
		[SerializeField] private TMP_Text m_unityTotalTextUI = default;

		//====================================================================================
		// 変数(readonly)
		//====================================================================================
		private readonly FPSCounter m_fPSCounter = new FPSCounter();

		//====================================================================================
		// 変数
		//====================================================================================
		private float m_timer;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 更新される時に呼び出されます
		/// </summary>
		private void Update()
		{
			m_fPSCounter.Update();

			m_timer += Time.unscaledDeltaTime;
			if ( m_timer < INTERVAL ) return;
			m_timer -= INTERVAL;

			var monoUsed   = ( Profiler.GetMonoUsedSizeLong() >> 10 ) / 1024f;
			var monoTotal  = ( Profiler.GetMonoHeapSizeLong() >> 10 ) / 1024f;
			var unityUsed  = ( Profiler.GetTotalAllocatedMemoryLong() >> 10 ) / 1024f;
			var unityTotal = ( Profiler.GetTotalReservedMemoryLong() >> 10 ) / 1024f;

			m_fpsTextUI.SetText( "{0}", ( int ) m_fPSCounter.Fps );
			m_gcTextUI.SetText( "{0}", GC.CollectionCount( 0 ) );
			m_monoUsedTextUI.SetText( "{0}", ( int ) monoUsed );
			m_monoTotalTextUI.SetText( "{0}", ( int ) monoTotal );
			m_unityUsedTextUI.SetText( "{0}", ( int ) unityUsed );
			m_unityTotalTextUI.SetText( "{0}", ( int ) unityTotal );
		}
	}
}
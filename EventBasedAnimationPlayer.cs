using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Anim
{
	public enum EventBasedAnimationPlayerState
	{
		Stop,
		Play, 
		Playing
	}

	public class EventBasedAnimationPlayer : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private bool _playOnStart = false;

		[SerializeField]
		private bool _loop = false;

		[SerializeField]
		private float _duration = 1f;

		[SerializeField]
		private UnityEventFloat _onUpdate;

		private EventBasedAnimationPlayerState _state = EventBasedAnimationPlayerState.Stop;
		private float _time = 0f;


		// Messages

		private void Start()
		{
			if(_playOnStart)
			{
				Play();
			}
		}

		private void Update()
		{
			if(_state == EventBasedAnimationPlayerState.Stop)
			{
				return;
			}
			else if(_state == EventBasedAnimationPlayerState.Play)
			{
				_time = 0f;
				Apply();

				_state = EventBasedAnimationPlayerState.Playing;
				return;
			}
			else
			{
				_time += Time.deltaTime;
				Apply();

				if(_time >= _duration)
				{
					_state = _loop ? EventBasedAnimationPlayerState.Play : EventBasedAnimationPlayerState.Stop;
				}
			}
		}

		public void Apply()
		{
			_onUpdate?.Invoke(Mathf.Clamp01(_time / _duration));
		}


		// Methods

		[ContextMenu("Play")]
		public void Play()
		{
			_state = EventBasedAnimationPlayerState.Play;
		}
	}
}

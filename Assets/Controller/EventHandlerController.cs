using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class EventHandlerController: MonoBehaviour, IEventHandler
	{
		virtual public void newGame() {
			Debug.Log ("Entered eventHandler");
		}

		virtual public void shoot() {
		}

		virtual public void shotAsteroid() {
		}

		virtual public void hit() {
		}

		virtual public void gameOver() {
		}
	}
}


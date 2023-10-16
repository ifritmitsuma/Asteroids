using System;
using UnityEngine.EventSystems;

namespace AssemblyCSharp
{
	public interface IEventHandler : IEventSystemHandler
	{

		void newGame();

		void shoot();

		void shotAsteroid();

		void hit();

		void gameOver();

	}
}


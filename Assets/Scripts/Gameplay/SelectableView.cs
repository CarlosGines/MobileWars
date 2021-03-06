﻿using UnityEngine;
using System.Collections;
using UniRx;

namespace EfrelGames {
	/// <summary>
	/// View related behaviour of a selectable.
	/// </summary>
	public abstract class SelectableView : MonoBehaviour {

		#region Extrnal references
		//======================================================================

		public Renderer[] playerColoredRends;

		#endregion


		#region Public methods
		//======================================================================

		/// <summary>
		/// View effects when selecting or unselecting this selectable.
		/// </summary>
		/// <param name="selected">If set to <c>true</c> selected.</param>
		public virtual void Selected (bool selected)
		{
		}
			
		/// <summary>
		/// View effects when moving to the specified position.
		/// </summary>
		/// <param name="pos">Position.</param>
		public virtual void Move (Vector3 pos)
		{
		}

		/// <summary>
		/// View effects when attacking the specified target.
		/// </summary>
		/// <param name="target">Target attackable.</param>
		public virtual void Attack (Attackable target)
		{
		}

		/// <summary>
		/// View effects when being attacked.
		/// </summary>
		public virtual void Targeted ()
		{
		}

		/// <summary>
		/// View effects when set the number of the player this selectable 
		/// belongs to.
		/// </summary>
		/// <param name="player">Player number.</param>
		public virtual void SetPlayerNum (int player)
		{
			Material mat = PlayersColors.playerMats [player];
			foreach (Renderer rend in playerColoredRends) {
				rend.material = mat;
			}
		}

		#endregion


		#region Context menu methods
		//======================================================================

		[ContextMenu ("Set References")]
		public virtual void SetReferences ()
		{
			GetComponentsInChildren <Renderer> ().ToObservable ()
				.Where (x => x.CompareTag ("PlayerColored"))
				.ToArray ()
				.Subscribe(rends => playerColoredRends = rends);
		}

		#endregion
	}
}

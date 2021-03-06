﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AugmentedGymnasium
{
	public class PongTeamSetUpArea : MonoBehaviour
	{
		/// <summary>
		/// The team associated with this set up area.
		/// </summary>
		[HideInInspector] public PongTeam pongTeam;

		void OnTriggerStay2D (Collider2D col)
		{
			if (col.tag == "Player"
				&& !GameManager.instance.hasGameStarted
				&& GameManager.instance.GetPlayerTeam(col.GetComponent<Player>()) == null) {
				pongTeam.ready = true;
				pongTeam.AddPlayer (col.GetComponent<Player> ());
				GetComponent<Animator> ().SetBool ("Activated", true);
			}
		}

		void OnTriggerExit2D (Collider2D col)
		{
			if (col.tag == "Player" && !GameManager.instance.hasGameStarted) {
				pongTeam.RemovePlayer (col.GetComponent<Player> ());
				if (pongTeam.players.Count == 0) {
					pongTeam.ready = false;
					GetComponent<Animator> ().SetBool ("Activated", false);
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	public static Quaternion LookAt2D(Transform game, Vector3 target){
		Vector2 direction = target - game.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
		return Quaternion.AngleAxis(angle, Vector3.forward);
	}

}

using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG 
{
    public class Slash : Ability
    {
        private string iconPath = "Sprites/Slash-Ability-Icon";

        private Transform charTransform;

        private Vector2 CharPosition { get { return charTransform.position + new Vector3(0, 0.5f); } }
        private Vector2 Direction { get { return (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)) - CharPosition; } }

        private RaycastHit2D[] attackHits;

        public Slash(Transform transform)
        {
            AbilityName = "Slash";

            attackHits = new RaycastHit2D[5];

            charTransform = transform;

            if (AbilityIcon == null)
                AbilityIcon = Resources.Load<Sprite>(iconPath);
        }

        /// <summary>
        /// Actual logic for the ability goes here. This is where the collision stuff goes.
        /// </summary>
        protected override void AbilityImplementation()
        {
            Debug.Log(Physics2D.BoxCastNonAlloc(CharPosition, new Vector2(1, 1f), 0, Direction.normalized, attackHits, 2, ~(1 << 8)));
        }
    }
}
﻿using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerHorizontalMover : MonoBehaviour
    {
        FlickInput flickInput;
        public int CurrentLine { get; set; }
        [SerializeField, Tooltip("左右移動にかける時間")] float moveTime;

        public bool IsMoving { get; set; }

        void Start()
        {
            flickInput = GetComponent<FlickInput>();
        }

        void Update()
        {
            Move();
        }
        void Move()
        {
            if (!IsMoving)
            {
                if ((Input.GetKeyDown(KeyCode.A) || flickInput.GetFlick(FlickDirection.Left)) && CurrentLine > -1)
                {
                    StartCoroutine(MoveCoroutine(Vector3.left));
                    CurrentLine--;
                }
                if ((Input.GetKeyDown(KeyCode.D) || flickInput.GetFlick(FlickDirection.Right)) && CurrentLine < 1)
                {
                    StartCoroutine(MoveCoroutine(Vector3.right));
                    CurrentLine++;
                }
            }
        }

        IEnumerator MoveCoroutine(Vector3 direction)
        {
            IsMoving = true;
            float defaultPositionX = transform.localPosition.x;
            float targetPositionX = defaultPositionX + direction.x;
            float time = 0;
            while (true)
            {
                transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, targetPositionX, time / moveTime), transform.localPosition.y, transform.localPosition.z);
                if (time > moveTime)
                {
                    break;
                }
                time += Time.deltaTime;
                yield return null;
            }
            IsMoving = false;
        }
    }
}

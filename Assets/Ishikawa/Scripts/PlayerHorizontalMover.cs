using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerHorizontalMover : MonoBehaviour
    {
        FlickInput flickInput;
        public int CurrentLine { get; set; }
        [SerializeField, Tooltip("左右移動にかける時間")] float moveTime;
        [SerializeField, Tooltip("移動の仕方")] AnimationCurve moveCurve;

        public bool IsMoving { get; set; }

        void Start()
        {
            flickInput = GetComponent<FlickInput>();
        }

        void Update()
        {
            if (GameManager.Instance.State == GameState.InGame)
            {
                Move();
            }
        }
        void Move()
        {
            if (!IsMoving)
            {
                if ((Input.GetKeyDown(KeyCode.A) || flickInput.GetFlick(FlickDirection.Left)) && CurrentLine > -1)
                {
                    StartCoroutine(MoveCoroutine(-1));
                }
                if ((Input.GetKeyDown(KeyCode.D) || flickInput.GetFlick(FlickDirection.Right)) && CurrentLine < 1)
                {
                    StartCoroutine(MoveCoroutine(1));
                }
            }
        }

        IEnumerator MoveCoroutine(int move)
        {
            IsMoving = true;
            bool isLineChanged = false;
            float defaultPositionX = transform.localPosition.x;
            float time = 0;
            while (true)
            {
                transform.localPosition = new Vector3(defaultPositionX + move * moveCurve.Evaluate(time / moveTime), 0, 0);
                if (!isLineChanged && moveCurve.Evaluate(time / moveTime) > 0.5f)
                {
                    CurrentLine += move;
                    isLineChanged = true;
                }
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

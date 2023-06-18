using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts
{
    public class DrawState : State
    {
        [SerializeField] private WhiteBoard whiteBoard;
        [SerializeField] private Pen pen;
        [SerializeField] private Transform penStartPosition;
        [SerializeField] private PaintCheck paintCheck;
        public override void Enter()
        {
            base.Enter();
            paintCheck.onPaintComplete += NextState;
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(delegate
            {
                pen.transform.DORotate(penStartPosition.eulerAngles, 0.5f);
                pen.transform.DOMove(penStartPosition.position, 0.5f).onComplete += delegate
                {
                    whiteBoard.DrawMode();
                    pen.DrawMode(true);
                };
            });
        }

        private void NextState()
        {
            pen.DrawMode(false);
            paintCheck.onPaintComplete -= NextState;
            fsm.NextState();
        }
    }
}
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts
{
    public class TrashState : State
    {
        [SerializeField] private Trash trash;
        [SerializeField] private Glass glass;
        public override void Enter()
        {
            trash.ColliderEnabled(true);
            trash.onClicked += GlassThrow;
            base.Enter();
        }

        public override void Exit()
        {
            trash.onClicked -= GlassThrow;
            base.Exit();
        }

        private void GlassThrow()
        {
            GetComponent<ObjectShaker>().enabled = false;
            glass.transform.DOScale(0.25f, 1f).SetEase(Ease.InOutSine);
            glass.transform.DOLocalRotate(new Vector3(720,0,0), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine);
            glass.transform.DOJump(trash.glassThrowPoint.position, 0.5f,1,0.5f).OnComplete(() =>
            {
                glass.transform.SetParent(null);
                glass.gameObject.SetActive(false);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(delegate
                {
                    fsm.NextState();
                });
            });
        }
    }
}
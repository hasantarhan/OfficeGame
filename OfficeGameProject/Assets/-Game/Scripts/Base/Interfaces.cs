using UnityEngine;

namespace _Game.Scripts
{
    public interface IClickable
    {
        public bool CanClick { get; set; }
        void OnClick();
    }
    public interface IColorable
    {
        void ChangeColor(Color color);
    }
}
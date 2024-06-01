using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign.UI
{
    public class PauseMenuPresenter : AbstractPresenter
    {
        public override void Repaint()
        {
        }

        public void ContinueClick()
        {
            Game.Instance.SetPlaying();
        }

        public void QuitClick()
        {
            //Game.Instance.SetMainMenu();
        }
    }
}
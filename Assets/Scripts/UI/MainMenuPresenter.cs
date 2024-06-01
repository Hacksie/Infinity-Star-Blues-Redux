using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign.UI
{
    public class MainMenuPresenter : AbstractPresenter
    {
        public override void Repaint()
        {
        }

        public void QuitClick()
        {
            Game.Instance.Quit();
        }        
    }
}
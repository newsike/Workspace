using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inspriation.Lib
{
    public class Util_Common
    {
        public static void Action_ClearAllInputControls(Control.ControlCollection activeFormControls)
        {
            foreach (Control activeControl in activeFormControls)
            {
                Type activeType = activeControl.GetType();
                if (activeType.FullName.Contains("TextBox"))
                    ((TextBox)activeControl).Text = "";
                else if (activeType.FullName.Contains("ComboBox"))
                    ((ComboBox)activeControl).Items.Clear();
                else if (activeType.FullName.Contains("CheckBox"))
                    ((CheckBox)activeControl).Checked = false;
                else if (activeType.FullName.Contains("ListView"))
                    ((ListView)activeControl).Items.Clear();
            }
        }

    }
}

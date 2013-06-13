using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;
using System.Windows.Forms;

namespace ort.edu.uy.obligatorio2.ClientDevicesGUI
{
    public class FormUtils
    {

        public static void MoveSingleItem(DeviceInfo device, ListBox from, ListBox to)
        {
            to.Items.Add(device);
            from.Items.Remove(device);
        }

        public static void MoveAllItems(ListBox from, ListBox to)
        {
            to.Items.AddRange(from.Items);
            from.Items.Clear();
        }

        public static bool TextBoxIsEmpty(TextBox txtBox)
        {
            return txtBox.Text == null || txtBox.Text.Trim().Equals("");
        }

    }
}

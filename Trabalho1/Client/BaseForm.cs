using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            Font = SystemFonts.MessageBoxFont;
        }

        public sealed override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
    }
}

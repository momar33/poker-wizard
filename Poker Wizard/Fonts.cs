using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Wizard
{
    class Fonts
    {
        private readonly Control defaultParent;

        public Fonts(Control main)
        {
            defaultParent = main;
        }

        public void ResizeAllFonts()
        {
            ResizeFonts(defaultParent);
        }

        public void ResizeFonts(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(Label) || c.GetType() == typeof(Button) || c.GetType() == typeof(NumericUpDown) || c.GetType() == typeof(TextBox))
                {
                    ResizeFont(c);
                }
                else
                {
                    ResizeFonts(c);
                }
            }
        }

        public static void ResizeFont(Control control)
        {
            // Only bother if there's text.
            string txt = control.Text;
            int best_size = 28;
            int wid, hgt;

            // See how much room we have, allowing a bit
            // for the Label's internal margin.
            if (control is Button)
            {
                wid = control.DisplayRectangle.Width - 20;
                hgt = control.DisplayRectangle.Height - 5;
            }
            else
            {
                wid = control.DisplayRectangle.Width - 0;
                hgt = control.DisplayRectangle.Height - 0;
            }


            // Make a Graphics object to measure the text.
            using (Graphics gr = control.CreateGraphics())
            {
                for (int i = 1; i <= 300; i++)
                {
                    using (Font test_font = new Font("Arial", i, FontStyle.Bold))
                    {
                        // See how much space the text would
                        // need, specifying a maximum width.
                        SizeF text_size = gr.MeasureString(txt, test_font);

                        if ((text_size.Width + control.Padding.Left + control.Padding.Right >= wid) || (text_size.Height + control.Padding.Top + control.Padding.Bottom >= hgt))
                        {
                            if (control.Name == "lblTime" || control.Name == "lblBlinds" || control.Name == "lblNextBlinds")// || control is Button)// || control is NumericUpDown)
                            {
                                best_size = i - 5;
                            }
                            else if (control.Name == "btnHomeScreen" || control.Name == "btnPlayersScreen" || control.Name == "btnAddPlayer" || control.Name == "lblNoRebuys")
                            {
                                best_size = i - 3;
                            }
                            else
                            {
                                best_size = i - 1;
                            }


                            break;
                        }
                    }
                }
            }

            // Use that font size.
            if (best_size < 1)
            {
                best_size = 1;
            }


            control.Font = new Font("Arial", best_size, FontStyle.Bold);

        }
    }
}

using System.Drawing;

namespace System.Windows.Forms
{
    public static class ControlHelper
    {
        public static Image PrintInvisibleControl(this Control targetControl)
        {
            using (Graphics g = targetControl.CreateGraphics())
            {
                //new bitmap object to save the image        
                var bmp = new Bitmap(targetControl.Width, targetControl.Height);
                //Drawing control to the bitmap        
                targetControl.DrawToBitmap(bmp, new Rectangle(0, 0, targetControl.Width, targetControl.Height));

                return bmp;
            }
        }

        public static void InvokeIfRequired(this System.ComponentModel.ISynchronizeInvoke ctrl, MethodInvoker act, params object[] args)
        {
            try
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.BeginInvoke(act, args);
                }
                else
                {
                    act();
                }
            }
            catch
            {
                // ToDo raise error log ...
            }
        }
    }
}

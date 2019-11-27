using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class SelectImage {
        public static string ImagePath;
        public void SelectAnImage(PictureBox pictureBox2, string picPathStr ) {
            OpenFileDialog Dialog = new OpenFileDialog( );
            Dialog.InitialDirectory = @"D:\My Files\ECD Pics";
            Dialog.Filter= "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if( Dialog.ShowDialog() == DialogResult.OK )
            {
                ImagePath = Dialog.FileName.ToString( );
                picPathStr = ImagePath;
                pictureBox2.ImageLocation = ImagePath;
            }           
            else
            {
                ImagePath = @"D:\My Files\My Programming\Programs Developed\Office\c# Projects\TextCodeMonitoring\TextCodeMonitoring\Resources\icon-person-64.png";
            }

        }
    }
}

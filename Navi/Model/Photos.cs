using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Navi.Model
{
    public static class Photos
    {
        public static DataSet PhotosTable = new DataSet();

        public static void SaveImageToDataBase(string fileName, int userId)
        {
            string shortFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);

            byte[] imageData;
            using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            DataSet ds = new DataSet();
            ViewModel.MyConnection myConn = new ViewModel.MyConnection();
            ds = myConn.GetData("SELECT * from photos", "photos");
            DataRow currentRow = ds.Tables["photos"].NewRow();
            currentRow[1] = userId;
            currentRow[2] = shortFileName;
            currentRow[3] = imageData;
            ds.Tables["photos"].Rows.Add(currentRow);

            myConn.UpdateData(ds, "photos");
            PhotosTable = ds;
        }

        public static void ReadImageFromDatabase()
        {
            List<ImageData> images = new List<ImageData>();
            DataSet ds = new DataSet();
            DataRow currentRow;
            ViewModel.MyConnection myConn = new ViewModel.MyConnection();
            ds = myConn.GetData("SELECT * from photos", "photos");
            PhotosTable = ds;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                currentRow = ds.Tables["photos"].Rows[i];
                ImageData image = new ImageData((int)currentRow.ItemArray.GetValue(0), (int)currentRow.ItemArray.GetValue(1), (string)currentRow.ItemArray.GetValue(2), (byte[])currentRow.ItemArray.GetValue(3));
                images.Add(image);
            }

            if (images.Count > 0)
            {
                string path = @"C:\\NaviImages";
                System.IO.Directory.CreateDirectory(path);
                images.ForEach(delegate (ImageData image)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(path + "\\" + image.FileName, System.IO.FileMode.OpenOrCreate))
                    {
                        fs.Write(image.Data, 0, image.Data.Length);
                    }
                });
            }
        }

        public static string GetUserPhoto(int userId)
        {
            DataRow[] resultRows;
            string path = @"C:\\NaviImages";
            resultRows = PhotosTable.Tables["photos"].Select("userId = '" + userId.ToString() + "'");
            if (resultRows.Length > 0)
            {
                return path + "\\" + resultRows[0].ItemArray.GetValue(2).ToString();
            }
            else
            {
                return path + "\\default-0000.jpg";
            }
        }
    }
}

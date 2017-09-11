using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace ImageColor
{

    public partial class Default : System.Web.UI.Page
    {
        Bitmap _current;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["filepath"] != null)
            {
                Img.ImageUrl = Session["filepath"].ToString();
                _current = (Bitmap)Bitmap.FromFile(Server.MapPath(Session["filepath"].ToString()));
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filePath = Server.MapPath("Images/" + FileUpload1.FileName);
                FileUpload1.SaveAs(filePath);
                Img.ImageUrl = "Images/" + FileUpload1.FileName;
                Session["filepath"] = "Images/" + FileUpload1.FileName;
            }
            else
            {
                Response.Write("Please Select The File");
            }
        }
        protected void btnInvert_Click(object sender, EventArgs e)
        {
            if (Session["filepath"] != null)
            {
                Bitmap temp = (Bitmap)_current;
                Bitmap bmap = (Bitmap)temp.Clone();
                Color col;
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        col = bmap.GetPixel(i, j);
                        bmap.SetPixel(i, j,
          Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B));
                    }
                }
                _current = (Bitmap)bmap.Clone();
                Random rnd = new Random();
                int a = rnd.Next();
                _current.Save(Server.MapPath("Images/" + a + ".png"));
                Img.ImageUrl = "Images/" + a + ".png";
            }

        }


    }
}

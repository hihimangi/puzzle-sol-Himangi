using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentShaps.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Bitmap bitmap = new Bitmap(1000, 1000);
        public ActionResult Index(FormCollection fc)
        {
            string shap = fc["shapMesure"];



            return View();
        }
        public ActionResult DrawShap(FormCollection fc)
        {
            string shaptxt = fc["shapMesure"];
            string shapName = Convert.ToString(shaptxt.Split(' ')[2]);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            switch (shapName.ToLower())
            {
                case "circle":
                    int radius = Convert.ToInt32(shaptxt.Split(' ')[7]);
                    g.DrawEllipse(pen, 20, 20, radius, radius);
                    break;
                case "square":
                    int length = Convert.ToInt32(shaptxt.Split(' ')[8]);
                    g.DrawRectangle(pen, 20, 20, length, length);
                    break;
                case "isosceles":
                    int firstSideIso = Convert.ToInt32(shaptxt.Split(' ')[9]);
                    int secondSideIso = Convert.ToInt32(shaptxt.Split(' ')[15]);
                    Point[] pointsIso = { new Point(10, secondSideIso), new Point(secondSideIso, 10), new Point(firstSideIso, secondSideIso) };
                    g.DrawPolygon(pen, pointsIso);
                    break;
                case "scalene":
                    int firstSideSca = Convert.ToInt32(shaptxt.Split(' ')[9]);
                    int secondSideSca = Convert.ToInt32(shaptxt.Split(' ')[15]);
                    int thirdSideSca = Convert.ToInt32(shaptxt.Split(' ')[21]);
                    Point[] pointsSca = { new Point(10, firstSideSca), new Point(secondSideSca, 10), new Point(firstSideSca, thirdSideSca) };
                    g.DrawPolygon(pen, pointsSca);
                    break;
                case "equilateral":
                    int firstSideEqu = Convert.ToInt32(shaptxt.Split(' ')[9]);
                    Point[] pointsEqu = { new Point(10, 10), new Point(firstSideEqu, 10), new Point(firstSideEqu / 2, firstSideEqu) };
                    g.DrawPolygon(pen, pointsEqu);
                    break;                                   
                case "pentagon":
                    int lengthPen = Convert.ToInt32(shaptxt.Split(' ')[8]);
                    Point[] pointsPen = { new Point(10, 10), new Point(lengthPen, 10), new Point(lengthPen, lengthPen / 2), new Point(lengthPen / 2, lengthPen), new Point(10, lengthPen / 2) };
                    g.DrawPolygon(pen, pointsPen);
                    break;
                case "hexagon":
                    int lengthHex = Convert.ToInt32(shaptxt.Split(' ')[8]);
                    var xHex = lengthHex / 2;
                    var yHex = lengthHex / 2;
                    var shape = new PointF[6];
                    var r = 70;                      
                    for (int a = 0; a < 6; a++)
                    {
                        shape[a] = new PointF(
                            xHex + r * (float)Math.Cos(a * 60 * Math.PI / 180f),
                            yHex + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
                    }                   
                    g.DrawPolygon(pen, shape);
                    break;
                case "rectangle":
                    int lengthRect = Convert.ToInt32(shaptxt.Split(' ')[7]);
                    int widthRect = Convert.ToInt32(shaptxt.Split(' ')[12]);
                    g.DrawRectangle(pen, 20, 20, lengthRect, widthRect);
                    break;                
                case "oval":
                    int radiusO1 = Convert.ToInt32(shaptxt.Split(' ')[8]);
                    int radiusO2 = Convert.ToInt32(shaptxt.Split(' ')[13]);
                    g.DrawEllipse(pen, 20, 30, radiusO1, radiusO2);
                    break;
                default:                    
                    break;
                
                                        

            }
            string circlepath = Server.MapPath("~/Image/cir.jpg");
            bitmap.Save(circlepath, ImageFormat.Jpeg);
            return View("Index");
        }

    }
}

using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace Lab6
{
    class Filter_c
    {
        public Image<Bgr, byte> diffusal(Image<Bgr, byte> image, Image<Gray, byte> background)
        {
            Image<Gray, byte> diff = background.AbsDiff(image.Convert<Gray, byte>());

            diff.Erode(3);
            diff.Dilate(4);

            Image<Gray, byte> binarizedImage = diff.ThresholdBinary(new Gray(30), new Gray(255));

            var copy = image.Copy();
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(binarizedImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > 50)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    copy.Draw(rect, new Bgr(Color.Blue), 1);
                }
            }

            return copy;
        }

        public Image<Bgr, byte> FilterMask(Image<Gray, byte> mask, Image<Bgr, byte> image)
        {
            var anchor = new Point(-1, -1);
            var borderValue = new MCvScalar(1);
            var kernel = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(3, 3), anchor);
            var closing = mask.MorphologyEx(MorphOp.Close, kernel, anchor, 1, BorderType.Default, borderValue);
            var opening = closing.MorphologyEx(MorphOp.Open, kernel, anchor, 1, BorderType.Default, borderValue);
            var dilation = opening.Dilate(7);
            var threshold = dilation.ThresholdBinary(new Gray(240), new Gray(255));

            var copy = image.Copy();
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(threshold, contours,null,RetrType.External,ChainApproxMethod.ChainApproxTc89L1);
            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i]) > 700)
                {
                    Rectangle boundingRect = CvInvoke.BoundingRectangle(contours[i]);
                    copy.Draw(boundingRect, new Bgr(Color.GreenYellow), 2);
                }
            }

            return copy;
        }
    }
}

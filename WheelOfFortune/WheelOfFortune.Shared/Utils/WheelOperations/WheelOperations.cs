//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFortune.Shared.Utils.WheelOperations
{
    public static class WheelOperations
    {
        /// <summary>
        /// This method is used for esthetic reasons. The purpose of this method is to
        /// align the top section with the spin button so that a proyected line matches
        /// the center of the wheel section that is on top.
        /// </summary>
        public static double AdjustWheelRotation(int numberOfSegments)
        {
            var sectionAngle = 360 / (double)numberOfSegments;
            var actualRotation = 270 % sectionAngle;
            var middle = sectionAngle / 2;
            if (actualRotation == 0)
            {
                var offset = actualRotation + middle;
                return offset;
            }
            else
            {
                var offset = actualRotation - middle;
                return offset;
            }
        }
        /// <summary>
        /// This method calculates the rotation of the images on the sections.
        /// Rotates all the images so that they end up facing the middle.
        /// More convenient if there are fewer sections.
        /// </summary>
        public static double CalculateSectionImgRotation(int sections, int section, double angleOffset)
        {
            var sectionAngle = 360 / (double)sections;
            //The section that matches 270 degrees or 90 in unit circle 
            var sectionTopCenter = Math.Ceiling(270 / sectionAngle);
            if (section > sectionTopCenter)
            {
                var segmentCount = section - sectionTopCenter;
                var output = (segmentCount * sectionAngle) - angleOffset;
                return output;
            }
            else if (section == sectionTopCenter)
            {
                var output = - angleOffset;
                return output;
            }
            else
            {
                var segmentCount = (sections - sectionTopCenter) + section;
                var output = (segmentCount * sectionAngle) - angleOffset;
                return output;
            }
        }
        /// <summary>
        /// The selected section visually(the section that matches the center of the top) and the state selected sections are not
        /// going to match. This method fix this. 
        /// </summary>
        public static double AdjustWheelSelectedResult(double degrees)
        {
            var revolutions = Math.Floor(degrees / 360);
            var reminder = degrees % 360;
            var rotationCounterClockwise = 360 - reminder;
            var total = (revolutions * 360) + rotationCounterClockwise - 90;
            return total;
        }
    }
}

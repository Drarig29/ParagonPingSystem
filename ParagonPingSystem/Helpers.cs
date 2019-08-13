using System;
using System.Windows;
using System.Windows.Media;

namespace ParagonPingSystem {

    public static class Helpers {

        /// <summary>
        /// Gets the 45° rotated quadrant in which the point is, based on the other.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="other"></param>
        /// <returns>0 for top, 1 for right, 2 for bottom, 3 for left</returns>
        public static int GetQuadrant(Point origin, Point other) {
            if (origin == other) {
                return -1;
            }
            
            var delta = other - origin;

            if (delta.Y < -delta.X &&
                delta.Y <= delta.X) {
                return 0;
            }

            if (delta.Y >= -delta.X &&
                delta.Y < delta.X) {
                return 1;
            }

            if (delta.Y > -delta.X &&
                delta.Y >= delta.X) {
                return 2;
            }

            if (delta.Y <= -delta.X &&
                delta.Y > delta.X) {
                return 3;
            }

            throw new NotSupportedException($"I didn't think about this! {origin} & {other}");
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject {
            while (true) {
                //get parent item
                var parentObject = VisualTreeHelper.GetParent(child);

                switch (parentObject) {
                    //we've reached the end of the tree
                    case null:
                        return null;
                    //check if the parent matches the type we're looking for
                    case T parent:
                        return parent;
                    default:
                        child = parentObject;
                        continue;
                }
            }
        }
    }
}
using System.Transactions;

namespace WheelOfFortune.Shared.Types
{
    public interface IUnitCircleInterval
    {
        public bool IsInRange(double currentDegree);
    }
    public class Interval : IUnitCircleInterval
    {
        public double Start { get; set; }
        public double End { get; set; }
        public bool IsInRange(double currentDegree)
        {
            var mod = currentDegree % 360;
            if(mod >= Start && mod < End)
            {
                return true;
            }

            return false;
        }
    }
}

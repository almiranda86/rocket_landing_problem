using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLandingApp.Behavior
{
    public interface ILandingService
    {
        Task<string> CanLand(int position);

        Task ManageLandingPlatform();
    }
}

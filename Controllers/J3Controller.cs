using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        [HttpPost("charge")]
        public string CanReachDestination([FromForm] int startX, [FromForm] int startY, [FromForm] int destX, [FromForm] int destY, [FromForm] int charge)
        {
            /// <summary>
            /// Determines if a destination can be reached given a starting point and charge.
            /// The function calculates the Manhattan distance between the starting point and destination.
            /// It checks if the available charge is sufficient to cover the distance and whether the 
            /// charge parity matches the distance parity.
            /// </summary>
            /// <param name="startX">The starting X coordinate.</param>
            /// <param name="startY">The starting Y coordinate.</param>
            /// <param name="destX">The destination X coordinate.</param>
            /// <param name="destY">The destination Y coordinate.</param>
            /// <param name="charge">The available charge to reach the destination.</param>
            /// <returns>
            /// "Y" if the destination can be reached with the available charge,
            /// "N" otherwise.
            /// </returns>
            /// <example>
            /// Input: startX = 0, startY = 0, destX = 3, destY = 4, charge = 7 
            /// Output: "Y" (distance is 7 and charge is 7)
            /// 
            /// Input: startX = 2, startY = 3, destX = 5, destY = 1, charge = 6 
            /// Output: "N" (distance is 5, charge is 6 but parity doesn't match)
            /// 
            /// Input: startX = 0, startY = 0, destX = 0, destY = 0, charge = 0 
            /// Output: "Y" (distance is 0 and charge is 0)
            /// </example>
            /// 
            int distance = Math.Abs(destX - startX) + Math.Abs(destY - startY);

            if (charge >= distance && (charge % 2 == distance % 2))
            {
                return "Y";
            }
            else
            {
                return "N";
            }
        }
    }
}

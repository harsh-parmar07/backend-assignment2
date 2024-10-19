using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : Controller
    {
        [HttpPost(template: "delevedroid")]
        public int delevedroid([FromForm] int deliveries, [FromForm] int collisions)
        {
            /// <summary>
            /// This method calculates the final score in a game where a robot droid delivers packages while avoiding obstacles.
            /// The score is determined based on the following rules:
            /// - Each delivered package earns 50 points.
            /// - Each collision with an obstacle results in a 10-point deduction.
            /// - If the number of deliveries exceeds the number of collisions, the player earns an additional 500 bonus points.
            /// The goal is to compute the final score at the end of the game.
            /// </summary>
            /// <param name="deliveries">The number of packages successfully delivered.</param>
            /// <param name="collisions">The number of obstacles the robot collided with.</param>
            /// <remarks>The robot earns bonus points if the deliveries are greater than the collisions.</remarks>
            /// <returns>Returns an integer representing the robot's total score.</returns>
            /// <example>
            /// Example inputs and outputs:
            /// deliveries = 5, collisions = 2  POST /api/j1/delevedroid -> 730
            /// deliveries = 0, collisions = 10 POST /api/j1/delevedroid -> -100
            /// deliveries = 2, collisions = 3  POST /api/j1/delevedroid -> 70
            /// </example>

            int t = 0;
            int delv = deliveries * 50;
            int coll = collisions * 10;
            t = delv - coll;
            if (deliveries > collisions)
            {
                t = t + 500;
            }
            return t;
        }


        [HttpPost(template: "mealcost")]
        public string MealCost([FromForm] int R, [FromForm] int G, [FromForm] int B)
        {
            /// <summary>
            /// This method calculates the total cost of a meal based on the number of red, green, and blue plates chosen.
            /// Each plate type has a fixed cost.
            /// The total cost is computed by multiplying the number of plates by their respective prices and summing the results.
            /// </summary>
            /// <param name="R">The number of red plates chosen by the customer.</param>
            /// <param name="G">The number of green plates chosen by the customer.</param>
            /// <param name="B">The number of blue plates chosen by the customer.</param>
            /// <returns>Returns a string showing the total cost of the meal.</returns>
            /// <example>
            /// Example inputs and outputs:
            /// R = 2, G = 3, B = 1  POST /api/sushi/mealcost -> "The total is: 23"
            /// R = 0, G = 0, B = 0  POST /api/sushi/mealcost -> "The total is: 0"
            /// R = 5, G = 2, B = 4  POST /api/sushi/mealcost -> "The total is: 43"
            /// </example>

            int redCost = 3;
            int greenCost = 4;
            int blueCost = 5;

            int totalCost = (R * redCost) + (G * greenCost) + (B * blueCost);

            return $"The total is: {totalCost}";
        }
    }
}

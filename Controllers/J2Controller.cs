using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class J2Controller : ControllerBase
        {
        /// <summary>
        /// This method determines the total spiciness of Ron's chili by evaluating the peppers included.
        /// Each type of pepper is assigned a specific Scoville Heat Unit (SHU) value, which is as follows:
        /// - Poblano: 1500 SHU
        /// - Mirasol: 6000 SHU
        /// - Serrano: 15500 SHU
        /// - Cayenne: 40000 SHU
        /// - Thai: 75000 SHU
        /// - Habanero: 125000 SHU
        /// The total spiciness is calculated by adding the SHU values of all peppers mentioned in the input string.
        /// </summary>
        /// <param name="ingredients">A string containing a list of pepper names, separated by commas, with each name corresponding to one from the SHU table.</param>
        /// <returns>An integer representing the total spiciness of the chili.</returns>
        /// <example>
        /// Example inputs and their outputs:
        /// ingredients = "Poblano, Cayenne, Thai, Poblano"  GET /api/j2/chilipeppers -> 118000
        /// ingredients = "Mirasol, Habanero"  GET /api/j2/chilipeppers -> 131000
        /// ingredients = "Poblano, Serrano"  GET /api/j2/chilipeppers -> 17000
        /// </example>
        [HttpGet(template: "chilipeppers")]
            public int chilipeppers(string ingredients)
            {
                int Poblano = 1500;
                int Mirasol = 6000;
                int Serrano = 15500;
                int Cayenne = 40000;
                int Thai = 75000;
                int Habanero = 125000;
                int total = 0;
                string[] all_peppers = ingredients.Split(',');

                foreach (string pepper in all_peppers)
                {
                    string t_pepper = pepper.Trim();
                    if (t_pepper == "Poblano"){
                        total = Poblano + total;
                    }
                    else if (t_pepper == "Mirasol"){
                        total = Mirasol + total;
                    }
                    else if (t_pepper == "Serrano"){
                        total = Serrano + total;
                    }
                    else if (t_pepper == "Cayenne"){
                        total = Cayenne + total;
                    }
                    else if (t_pepper == "Thai"){
                        total = Thai + total;
                    }
                    else{
                        total = Habanero + total;
                    }
                }

                return total;
            }


        [HttpPost("auction")]
        public IActionResult SilentAuction([FromBody] List<Bid> bids)
        {
            /// <summary>
            /// This method processes bids for a silent auction. It accepts a list of bids and determines the highest bid.
            /// If no bids are provided, it returns a bad request response.
            /// </summary>
            /// <param name="bids">A list of Bid objects, each containing a name and bid amount.</param>
            /// <returns>An IActionResult containing the name of the highest bidder if bids are provided; otherwise, a bad request message.</returns>
            /// <example>
            /// If the bids are empty or null, the method will return:
            /// BadRequest("No bids were provided.")
            /// If the bids contain valid entries, it will return the name of the highest bidder.
            /// </example>

            if (bids == null || bids.Count == 0)
            {
                return BadRequest("No bids were provided.");
            }

            int maxBid = 0;
            string winnerName = "";

            foreach (var bid in bids)
            {
                if (bid.Amount > maxBid)
                {
                    maxBid = bid.Amount;
                    winnerName = bid.Name;
                }
            }

            return Ok(winnerName);
        }

        public class Bid
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }
    }
}

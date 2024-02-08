using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOfffer;

namespace RocketseatAuction.API.Controllers;
[ServiceFilter(typeof(AuthenticationUserAttribute))]

public class OfferController : ControllerBase
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}

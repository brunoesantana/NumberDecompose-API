using Microsoft.AspNetCore.Mvc;
using NumberDecompose.Business.Interface;
using NumberDecompose.Controllers.Base;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.CrossCutting.Exceptions;
using NumberDecompose.Domain;
using System.Net;

namespace NumberDecompose.Controllers
{
    [Route("api/v1/number")]
    public class NumberController : ControllerBase<Number, NumberDTO, NumberInsertDTO, NumberUpdateDTO>
    {
        public NumberController(INumberService numberService) : base(numberService)
        {
        }

        [HttpGet("decompose")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Decompose(int value)
        {
            var response = ((INumberService)_service).Decompose(value);

            return response != null ? Ok(response) : throw new NotFoundException();
        }
    }
}
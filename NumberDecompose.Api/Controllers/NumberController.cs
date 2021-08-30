using Microsoft.AspNetCore.Mvc;
using NumberDecompose.Business.Interface;
using NumberDecompose.Controllers.Base;
using NumberDecompose.CrossCutting.DTO.Number;
using NumberDecompose.CrossCutting.Exceptions;
using NumberDecompose.Domain;
using System;
using System.Net;

namespace NumberDecompose.Controllers
{
    [Route("api/v1/number")]
    public class NumberController : ControllerBase<Number, NumberDTO, NumberResumedDTO, NumberInsertDTO, NumberUpdateDTO>
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

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult GetAll()
        {
            return base.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Get(Guid id)
        {
            return Find(id);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Add([FromBody] NumberInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] NumberUpdateDTO model)
        {
            return base.Update(id, model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}
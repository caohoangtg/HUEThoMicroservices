using Catalog.Application.Features.Catalogs.Commands;
using Catalog.Application.Features.Catalogs.Queries;
using Catalog.Application.Utilities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    public class CatalogController : BaseApiController
    {
        #region Queries

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProducts()
        {
            return HandleResult(await Mediator.Send(new GetProductsListQuery()));
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetProductQuery(id)));
        }

        [HttpGet("{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProductByCategory(string category)
        {
            return HandleResult(await Mediator.Send(new GetProductByCategoryQuery(category)));
        }

        [HttpGet("GetProductsPaged", Name = "GetProductsPaged")]
        [ProducesResponseType(typeof(PagedList<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProductsPaged([FromQuery] PagingParams param)
        {
            return HandlePagedResult(await Mediator.Send(new GetProductsPagedQuery(param)));
        }

        #endregion

        #region Command

        [HttpPut(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpPost(Name = "UpdateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteProductCommand(id)));
        }

        #endregion
    }
}

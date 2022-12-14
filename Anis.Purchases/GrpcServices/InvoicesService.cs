using Anis.Purchases.Extensions;
using Anis.Purchases.InvoicesProto.V1;
using Grpc.Core;
using MediatR;
using System.Threading.Tasks;

namespace Anis.Purchases.GrpcServices
{
    public class InvoicesService : Invoices.InvoicesBase
    {
        private readonly IMediator _mediator;

        public InvoicesService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public override async Task<Response> Create(CreateRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = "Success Created"
            };
        }

        public override async Task<Response> UpdateInfo(UpdateInfoRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = "Success Updated"
            };
        }

        public override async Task<Response> AddItem(AddItemRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> AddShipment(AddShipmentRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> AdjustDamagedQuantity(AdjustDamagedQuantityRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> AssignSupplier(SupplierRequest request, ServerCallContext context)
        {
            var command = request.ToAssignCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> CancelDelivery(CancelDeliveryRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> ChangeDeadline(ChangeDeadlineRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> ChangeSupplier(SupplierRequest request, ServerCallContext context)
        {
            var command = request.ToChangeCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> Close(CloseRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> ConfirmShipping(ConfirmShippingRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            await _mediator.Send(command);

            return new DeleteResponse()
            {
                Message = ""
            };
        }

        public override async Task<Response> Deliver(DeliverRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> RemoveItem(RemoveItemRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> RemoveShipment(RemoveShipmentRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> UnconfirmShipping(UnconfirmShippingRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> UpdateItem(UpdateItemRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }

        public override async Task<Response> UpdateShipment(UpdateShipmentRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invoice = await _mediator.Send(command);

            return new Response()
            {
                Output = invoice.ToOutput(),
                Message = ""
            };
        }
    }
}

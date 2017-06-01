using Lq.Service.Models.Query;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Lq.Service.Extensions
{
    public class QueryModelParameterBinding : HttpParameterBinding
    {
        private struct AsyncVoid { }
        public QueryModelParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var request = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);
            var model = new QueryModel(request);

            SetValue(actionContext, model);

            TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
            tcs.SetResult(default(AsyncVoid));
            return tcs.Task;
        }
    }
}
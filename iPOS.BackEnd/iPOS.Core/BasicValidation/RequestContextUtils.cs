using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Net;

namespace iPOS.Core.BasicValidation
{
    internal static class RequestContextUtils
    {
        public static void Unauthorized(ref RequestContext context, string nonauthorizedHeaderValue)
        {
            var reply = Message.CreateMessage(MessageVersion.None, null);
            var responseProperty = new HttpResponseMessageProperty() { StatusCode = HttpStatusCode.Unauthorized };

            responseProperty.Headers.Add(HttpResponseHeader.WwwAuthenticate,
                                         nonauthorizedHeaderValue);

            reply.Properties[HttpResponseMessageProperty.Name] = responseProperty;
            context.Reply(reply);
            context = null;
        }

        public static HttpRequestMessageProperty GetHttpRequestMessage(this Message requestMessage)
        {
            return (HttpRequestMessageProperty)requestMessage.Properties[HttpRequestMessageProperty.Name];
        }
    }
}

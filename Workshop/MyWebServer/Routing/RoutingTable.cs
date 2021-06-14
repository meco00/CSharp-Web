﻿using MyWebServer.Common;
using MyWebServer.Http;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Routing
{
    public class RoutingTable : IRoutingTable
    {

        private readonly Dictionary<HttpMethod,Dictionary<string,Func<HttpRequest,HttpResponse>>> routes;

        public RoutingTable()
           => this.routes = new()
           {
               [HttpMethod.Get] = new(),
               [HttpMethod.Post] = new(),
               [HttpMethod.Put] = new(),
               [HttpMethod.Delete] = new()
           };



        public IRoutingTable Map( HttpMethod method, string path, HttpResponse response)
        {
           
            Guard.AgainstNull(response, nameof(response));

           

            return this.Map(method,path,request=> response);
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
        =>MapGet(path,request=>response);

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
        => Map(HttpMethod.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, HttpResponse response)
       => MapPost(path, request=>response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
         => Map(HttpMethod.Post, path, responseFunction);

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod)||
                !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new HttpResponse(HttpStatusCode.NotFound);

            }

            var responseFunc = this.routes[requestMethod][requestUrl];

            return responseFunc(request);

        }

        
    }
}

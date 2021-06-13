﻿using MyWebServer.Common;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
           : base(text, HttpContentType.PlainText)
        {

        }
    }
}